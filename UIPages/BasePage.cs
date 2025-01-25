using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UIPage;

public class BasePage(IWebDriver webDriver)
{
    private readonly IWebDriver _webDriver = webDriver;

    public IWebElement WaitForElementVisible(string xpath)
    {
        WebDriverWait webDriverWait = new(_webDriver, TimeSpan.FromSeconds(500));
        return webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
    }

    public void WaitForPageToLoad()
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_webDriver;

        WebDriverWait wait = new(_webDriver, TimeSpan.FromSeconds(30));
        wait.Until(driver =>
        {
            // Check the document's readyState using
            return jsExecutor.ExecuteScript("return document.readyState").ToString() == "complete";
        });

        Console.WriteLine("Page has fully loaded.");
    }
}

