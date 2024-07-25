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
            // SetUp�A�g���r���[�g��ݒ肷��ƁA�e�e�X�g���\�b�h�����s�����O�Ɏ��s����܂��B
            mainWindowVM = new MainWindowVM();
        }

        [Test]
        public void Test1()
        {
            int expectedId = 0;

            // ��{�I�ɏo�͂��m�F���鎞��Assert.That���g���܂��B
            // �ȉ��̗�ł́AexpectedId��mainWindowVM.InsertId()�������������m�F���Ă��܂��B
            Assert.That(expectedId, Is.EqualTo(mainWindowVM.InsertId()));
        }

        /**
         * �ȉ��̃\�[�X�R�[�h�̓��b�N������ꍇ�̃\�[�X�R�[�h
         * �������ΏۃN���X�̃v���p�e�B�⃁�\�b�h��vaitual�A�E�����K�{�ƂȂ�B
         * ������protected�ȏオ�K�v�B
         * �܂�static�ȃ��\�b�h�����b�N���ł��Ȃ��B
         * 
         *   [Test]
         *   public void �N���X�̃v���p�e�B�����b�N�������ۂ̋������m�F���邽��User�N���X��Id�v���p�e�B�����b�N�����܂�()
         *   {
         *       int expectedId = 99;
         *
         *       // ���b�N���쐬����ۂɂ�Mock<T>���g���܂��B
         *       // T�̓��b�N�Ώۂ̃N���X���w�肵�܂��B
         *       // �����̓R���X�g���N�^�̈������w�肵�܂��B
         *       // �v���p�e�B��CallBase=true��ݒ肷��ƁA���b�N���ݒ�̃��\�b�h�͎��ۂ̃N���X�̃��\�b�h���Ă΂�܂��B
         *       var mockUser = new Mock<User>(0, "takata", "kento") { CallBase=true };
         *
         *       // �v���p�e�B�����b�N�����܂��B
         *       // �ȉ��̗�ł�Id�v���p�e�B�����b�N�����AId�v���p�e�B��0��Ԃ��悤�ɐݒ肵�Ă��܂��B
         *       mockUser.SetupGet(x => x.Id).Returns(99);
         *       int result = mockUser.Object.Id;
         *
         *       Assert.That(expectedId, Is.EqualTo(result));
         *   }
         *
         *   [Test]
         *   public void �N���X�̃��\�b�h�����b�N�������ۂ̋������m�F���邽��User�N���X��GetFirstName���\�b�h�����b�N�����܂�()
         *   {
         *       string expectedFirstName = "takata";
         *
         *       // �v���p�e�B��CallBase=false��ݒ肷��ƁA���b�N���ݒ�̃��\�b�h��null���Ă΂�܂��B
         *       // �Ȃ��f�t�H���g��CallBase�v���p�e�B��false�̂��߁A�ȗ��\�ł��B
         *       var mockUser = new Mock<User>(0, "FirstName", "MiddleName", "LastName") { CallBase=false };
         *
         *       // ���\�b�h�����b�N�����܂��B
         *       // �ȉ��̗�ł�GetFirstName���\�b�h�����b�N�����A"takata"��Ԃ��悤�ɐݒ肵�Ă��܂��B
         *       mockUser.Setup(x => x.GetFirstName()).Returns("takata");
         *       string result = mockUser.Object.GetFirstName();
         *
         *       Assert.That(expectedFirstName, Is.EqualTo(result));
         *   }
         *
         *
         */

    }
}