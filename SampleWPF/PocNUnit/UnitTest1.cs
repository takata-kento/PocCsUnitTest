using Moq;
using SampleWPF.ViewModels;
using SampleWPF.Models;
namespace PocNUnit
{
    public class Tests
    {
        MainWindowVM mainWindowVM;

        [SetUp]
        public void Setup()
        {
            // SetUpアトリビュートを設定すると、各テストメソッドが実行される前に実行されます。
            mainWindowVM = new MainWindowVM();
        }

        [Test]
        public void Test1()
        {
            int expectedId = 0;

            // 基本的に出力を確認する時はAssert.Thatを使います。
            // 以下の例では、expectedIdとmainWindowVM.InsertId()が等しいかを確認しています。
            Assert.That(expectedId, Is.EqualTo(mainWindowVM.InsertId()));
        }

        [Test]
        public void クラスのプロパティをモック化した際の挙動を確認するためUserクラスのIdプロパティをモック化します()
        {
            int expectedId = 99;

            // モックを作成する際にはMock<T>を使います。
            // Tはモック対象のクラスを指定します。
            // 引数はコンストラクタの引数を指定します。
            // プロパティにCallBase=trueを設定すると、モック未設定のメソッドは実際のクラスのメソッドが呼ばれます。
            var mockUser = new Mock<User>(0, "takata", "kento") { CallBase=true };

            // プロパティをモック化します。
            // 以下の例ではIdプロパティをモック化し、Idプロパティが0を返すように設定しています。
            mockUser.SetupGet(x => x.Id).Returns(99);

            Assert.That(expectedId, Is.EqualTo(mockUser.Object.Id));
        }

        [Test]
        public void クラスのメソッドをモック化した際の挙動を確認するためUserクラスのGetFirstNameメソッドをモック化します()
        {
            string expectedFirstName = "takata";

            // プロパティにCallBase=falseを設定すると、モック未設定のメソッドはnullが呼ばれます。
            // なおデフォルトでCallBaseプロパティはfalseのため、省略可能です。
            var mockUser = new Mock<User>(0, "FirstName", "LastName") { CallBase=false };

            // メソッドをモック化します。
            // 以下の例ではGetFirstNameメソッドをモック化し、"takata"を返すように設定しています。
            mockUser.Setup(x => x.GetFirstName()).Returns("takata");

            Assert.That(expectedFirstName, Is.EqualTo(mockUser.Object.GetFirstName()));
        }
    }
}