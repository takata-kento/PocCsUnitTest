using SampleWPF.ViewModels;
namespace PocxUnit
{
    public class UnitTest1
    {
        MainWindowVM mainWindowVM = new MainWindowVM();

        [Fact]
        public void Test1()
        {
            int expectedId = 0;
            Assert.Equal(expectedId, mainWindowVM.InsertId());
        }
    }
}