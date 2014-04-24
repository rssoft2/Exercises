using System;

namespace BindFlowToProvider
{
    class Program
    {
        static void Main()
        {
            FlowWithInjectedProviders();

            FlowWithInjectedProvidersAndContinuations();
        }

        private static void FlowWithInjectedProviders()
        {
            // Build/Bind
            ISomeDataProvider someDataProvider = new MyConsoleDataProvider();
            ISomeDataSink someDataSink = new MyConsoleDataSink();
            // Run
            Flows.FlowNeedingProvider(someDataProvider, someDataSink);
        }

        private static void FlowWithInjectedProvidersAndContinuations()
        {
            // Build/Bind
            ISomeDataProviderWithContinuation someDataProviderWithContinuation = new MyConsoleDataProviderWithContinuation();
            ISomeDataSinkWithContinuation someDataSinkWithContinuation = new MyConsoleDataSinkWithContinuation();
            // Run
            Flows.FlowNeedingProviderWithContinuation(
                someDataProviderWithContinuation,
                someDataSinkWithContinuation,
                AnSuccessFunc,
                AnErrorFunc);
        }

        private static void AnSuccessFunc(double d)
        {
            Console.WriteLine(":-)");
        }

        private static void AnErrorFunc(string s)
        {
            Console.WriteLine(":-( {1}--> {0}", s, Environment.NewLine);
            //throw new Exception(string.Format("Error: {0}", d));
        }
    }
}
