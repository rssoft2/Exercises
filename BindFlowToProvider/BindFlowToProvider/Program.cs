using System;

namespace BindFlowToProvider
{
    class Program
    {
        static void Main()
        {
            // Build/Bind
            ISomeDataProvider someDataProvider = new MyConsoleDataProvider();
            ISomeDataSink someDataSink = new MyConsoleDataSink();
            // Run
            Flows.FlowNeedingProvider(someDataProvider, someDataSink);
        }
    }

    public static class Flows
    {
        public static void FlowNeedingProvider(ISomeDataProvider someDataProvider, ISomeDataSink someDataSink)
        {
            var providedData = someDataProvider.GetSomeData();
            var calculatedData = Calc(providedData);
            someDataSink.WriteSomeData(calculatedData);
        }

        static private double Calc(double data)
        {
            return data / 2.0;
        }
    }

    public interface ISomeDataProvider
    {
        double GetSomeData();
    }

    public interface ISomeDataSink
    {
        void WriteSomeData(double data);
    }

    class MyConsoleDataProvider : ISomeDataProvider
    {
        public double GetSomeData()
        {
            double result;
            return double.TryParse(Console.ReadLine(), out result) ? result : 0;
        }
    }

    class MyConsoleDataSink : ISomeDataSink
    {
        public void WriteSomeData(double data)
        {
            Console.WriteLine("Result: {0}", data);
        }
    }
}
