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
}

