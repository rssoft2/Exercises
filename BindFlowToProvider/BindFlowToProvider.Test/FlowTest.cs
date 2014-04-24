using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BindFlowToProvider.Test
{
    [TestClass]
    public class FlowTest
    {
        [TestMethod]
        public void TestFlowNeedingProviderWithTestMocks()
        {
            Flows.FlowNeedingProvider(new MyTestDataProvider(), new MyTestDataSink());
        }

        [TestMethod]
        public void TestFlowNeedingProviderWithContinuationWithTestMocks()
        {
            Flows.FlowNeedingProviderWithContinuation(new MyTestDataProviderWithContinuation(), new MyTestDataSinkWithContinuation(), 
                d => Assert.AreEqual(61728, d), 
                s => new AssertFailedException(s));
        }
    }

    class MyTestDataProvider : ISomeDataProvider
    {
        public double GetSomeData()
        {
            return 123456;
        }
    }

    class MyTestDataSink : ISomeDataSink
    {
        public void WriteSomeData(double data)
        {
            Assert.AreEqual(61728, data);
        }
    }

    class MyTestDataProviderWithContinuation : ISomeDataProviderWithContinuation
    {
        public void GetSomeData(Action<double> onSuccessFunc, Action<string> onErrorFunc)
        {
            onSuccessFunc(123456);
        }
    }

    class MyTestDataSinkWithContinuation : ISomeDataSinkWithContinuation
    {
        public void WriteSomeData(double calculatedData, Action<double> onSuccessFunc)
        {
            onSuccessFunc(calculatedData);
        }
    }
}

