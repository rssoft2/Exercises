using System;

namespace BindFlowToProvider
{
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

    class MyConsoleDataProviderWithContinuation : ISomeDataProviderWithContinuation
    {
        public void GetSomeData(Action<double> onSuccessFunc, Action<string> onErrorFunc)
        {
            double result;
            var input = Console.ReadLine();
            if (double.TryParse(input, out result))
            {
                onSuccessFunc(result);
                return;
            }
            onErrorFunc(string.Format("Error parsing input: {0}", input));
        }
    }

    class MyConsoleDataSinkWithContinuation : ISomeDataSinkWithContinuation
    {
        public void WriteSomeData(double data, Action<double> onSuccessFunc)
        {
            Console.WriteLine("Result: {0}", data);
            onSuccessFunc(data);
        }
    }
}