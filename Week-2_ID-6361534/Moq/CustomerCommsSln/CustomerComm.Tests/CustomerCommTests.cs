using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommTests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Init()
        {
            // Arrange: Create mock and setup
            _mockMailSender = new Mock<IMailSender>();

            // Setup mock to always return true for any input
            _mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Inject mock into CustomerComm
            _customerComm = new CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMocked()
        {
            // Act
            var result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.That(result, Is.True);
        }
    }
}

}
