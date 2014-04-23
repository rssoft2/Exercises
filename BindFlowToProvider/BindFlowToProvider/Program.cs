using System;

namespace BindFlowToProvider
{
    class Program
    {
        static void Main()
        {
            #region Flow with injected Providers
            // Build/Bind
            ISomeDataProvider someDataProvider = new MyConsoleDataProvider();
            ISomeDataSink someDataSink = new MyConsoleDataSink();
            // Run
            Flows.FlowNeedingProvider(someDataProvider, someDataSink);
            #endregion

            #region Flow with injected Providers and Continuations
            // Build/Bind
            ISomeDataProviderWithContinuation someDataProviderWithContinuation = new MyConsoleDataProviderWithContinuation();
            ISomeDataSinkWithContinuation someDataSinkWithContinuation = new MyConsoleDataSinkWithContinuation();
            // Run
            Flows.FlowNeedingProviderWithContinuation(
                someDataProviderWithContinuation, 
                someDataSinkWithContinuation,
                AnSuccessFunc, 
                AnErrorFunc);
            #endregion
        }

        private static void AnSuccessFunc(double d)
        {
            Console.WriteLine(":-)");
        }

        private static void AnErrorFunc(string d)
        {
            throw new Exception(string.Format("Error: {0}", d));
        }
    }
}
