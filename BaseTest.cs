using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CICDSelenium
{
    public class BaseTest
    {
        protected IWebDriver? Driver;

        public BaseTest()
        {
            string browser = "chrome";

            Driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new NotImplementedException("Browser not supported."),
            };
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        // Cleanup after each test
        [TearDown]
        public void Teardown()
        {
            Driver?.Quit();
        }

        public void NavigateToApplicationUrl()
        {
            Driver?.Navigate().GoToUrl("https://demo.automationtesting.in/Register.html");
            Driver?.Manage().Window.Maximize();
        }

        public void TakeScreenshot(string testName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)Driver!;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine("screenshots", $"{testName}_{DateTime.Now:yyyyMMddHHmmss}.png");

            if (!Directory.Exists("screenshots"))
            {
                Directory.CreateDirectory("screenshots");
            }

            File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);

            // Attach screenshot to Allure report
            AllureLifecycle.Instance.AddAttachment(testName, "image/png", screenshotPath);
        }
    }
}