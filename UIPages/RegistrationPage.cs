using OpenQA.Selenium;
using UIPage;

namespace UIPages;

public class RegistrationPage : BasePage
{
    private readonly IWebDriver _webdriver;
    public RegistrationPage(IWebDriver webdriver) : base(webdriver)
    {
        _webdriver = webdriver;
    }

    private string firstNameLocator = "//input[@placeholder='First Name']";

    private IWebElement FirstName => _webdriver.FindElement(By.XPath(firstNameLocator));

    private string lastNameLocator = "//input[@placeholder='Last Name']";

    private IWebElement LastName => _webdriver.FindElement(By.XPath(lastNameLocator));

    private string addressLocator = "//textarea[@ng-model='Adress']";

    private IWebElement Address => _webdriver.FindElement(By.XPath(addressLocator));

    private string emailLocator = "//input[@type='email']";

    private IWebElement Email => _webdriver.FindElement(By.XPath(emailLocator));

    private string telLocator = "//input[@type='tel']";

    private IWebElement Tel => _webdriver.FindElement(By.XPath(telLocator));

    private string genderMaleLocator = "//input[@type='radio'][@value='Male']";

    private IWebElement GenderMale => _webdriver.FindElement(By.XPath(genderMaleLocator));

    private string countryLocator = "//select[@type='text']/option[text()='Select Country']/option";

    private string selectCountryLocator = "//span[@role='combobox']";

    private IWebElement SelectCountry => _webdriver.FindElement(By.XPath(selectCountryLocator));

    private string selectCountrySearchLocator = "//input[@type='search']";

    private IWebElement SelectCountrySearch => _webdriver.FindElement(By.XPath(selectCountrySearchLocator));

    private string selectSpecificCountrySearchLocator = "//span[@class='select2-results']//li[text()='replacer']";

    private string submitButtonLocator = "//button[@id='submitbtn']";

    private IWebElement SubmitButton => _webdriver.FindElement(By.XPath(submitButtonLocator));

    public void EnterFirstAndLastName(string firstName, string lastName)
    {
        WaitForElementVisible(firstNameLocator);
        FirstName.SendKeys(firstName);
        LastName.SendKeys(lastName);
    }

    public void EnterAddress(string address)
    {
        WaitForElementVisible(addressLocator);
        Address.SendKeys(address);
    }

    public void EnterEmail(string emailId)
    {
        WaitForElementVisible(emailLocator);
        Email.SendKeys(emailId);
    }

    public void EnterPhoneNumber(string phoneNumber)
    {
        WaitForElementVisible(telLocator);
        Tel.SendKeys(phoneNumber);
    }

    public void ClickOnMaleGender()
    {
        WaitForElementVisible(genderMaleLocator);
        GenderMale.Click();
    }

    public void SelectAndEnterCountryName(string countryName)
    {
        WaitForElementVisible(selectCountrySearchLocator);
        SelectCountrySearch.SendKeys(countryName);
        WaitForElementVisible(selectSpecificCountrySearchLocator.Replace("replacer", countryName)).Click();
    }

    public void ClickOnSubmitButton()
    {
        WaitForElementVisible(submitButtonLocator);
        SubmitButton.Click();
    }

    public string CountryToolTipText() => WaitForElementVisible(countryLocator).GetDomAttribute("text");
}

