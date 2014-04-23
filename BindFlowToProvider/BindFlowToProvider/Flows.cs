using System;

namespace BindFlowToProvider
{
    public static class Flows
    {
        public static void FlowNeedingProvider(ISomeDataProvider someDataProvider, ISomeDataSink someDataSink)
        {
            var providedData = someDataProvider.GetSomeData();
            var calculatedData = Calc(providedData);
            someDataSink.WriteSomeData(calculatedData);
        }

        public static void FlowNeedingProviderWithContinuation(ISomeDataProviderWithContinuation someDataProvider, ISomeDataSinkWithContinuation someDataSink, Action<double> onSuccessFunc, Action<string> onErrorFunc)
        {
            var providedData = someDataProvider.GetSomeData(onSuccessFunc, onErrorFunc);
            var calculatedData = Calc(providedData);
            someDataSink.WriteSomeData(calculatedData, onSuccessFunc);
        }

        static private double Calc(double data)
        {
            return data / 2.0;
        }
    }
}