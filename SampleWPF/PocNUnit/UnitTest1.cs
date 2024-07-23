using SampleWPF.ViewModels;
namespace PocNUnit
{
    public class Tests
    {
        MainWindowVM mainWindowVM;

        [SetUp]
        public void Setup()
        {
            mainWindowVM = new MainWindowVM();
        }

        [Test]
        public void Test1()
        {
            int expectedId = 0;
            Assert.That(expectedId, Is.EqualTo(mainWindowVM.InsertId()));
        }
    }
}