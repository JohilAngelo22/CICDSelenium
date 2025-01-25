using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using UICore;

namespace CICDSelenium
{
    [TestFixture]
    [AllureNUnit]
    public class RegistrationTest : BaseTest
    {
        readonly RegistrationPage registrationPage;

        [SetUp]
        public void NavigateToApplication()
        {
            NavigateToApplicationUrl();
        }
        public RegistrationTest():base()
        {
            registrationPage = new(Driver!);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]  // Allure severity annotation
        [AllureOwner("TesterName")]
        [AllureSuite("Selenium Tests")]
        public void RegistrationSubmissionTests()
        {
            registrationPage.EnterFirstAndLastName("Johil", "Angelo");
            registrationPage.EnterAddress("Kallaravilai");
            registrationPage.EnterEmail("automationcheck@gmail.com");
            registrationPage.ClickOnMaleGender();
            registrationPage.EnterPhoneNumber("9442738206");
            registrationPage.ClickOnSubmitButton();

            var hjhj = registrationPage.CountryToolTipText();
        }
    }
}
