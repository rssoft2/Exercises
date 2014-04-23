using System;

namespace BindFlowToProvider
{
    public interface ISomeDataProvider
    {
        double GetSomeData();
    }

    public interface ISomeDataSink
    {
        void WriteSomeData(double data);
    }

    public interface ISomeDataProviderWithContinuation
    {
        double GetSomeData(Action<double> onSuccessFunc, Action<string> onErrorFunc);
    }

    public interface ISomeDataSinkWithContinuation
    {
        void WriteSomeData(double calculatedData, Action<double> onSuccessFunc);
    }
}