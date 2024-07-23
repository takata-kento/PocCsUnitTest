using SampleWPF.ViewModels;
namespace PocMSTest
{
    [TestClass]
    public class UnitTest1
    {
        MainWindowVM mainWindowVM = new MainWindowVM();

        [TestMethod]
        public void TestMethod1()
        {
            int expectedId = 0;
            Assert.AreEqual(expectedId, mainWindowVM.InsertId());
        }
    }
}