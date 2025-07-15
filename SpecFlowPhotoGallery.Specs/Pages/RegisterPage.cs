using OpenQA.Selenium;

namespace SpecFlowPhotoGallery.Specs.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Logo => _driver.FindElement(By.XPath("//app/master-layout/baasic-header/header/div"));
        public IWebElement RegisterBanner => _driver.FindElement(By.XPath("//baasic-registration//h2"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("email"));
        public IWebElement UsernameTextbox => _driver.FindElement(By.Id("userName"));
        public IWebElement PasswordTextbox => _driver.FindElement(By.Id("password"));
        public IWebElement ConfirmPasswordTextbox => _driver.FindElement(By.Id("confirmPassword"));
        public IWebElement RegisterButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement ErrorMessage => _driver.FindElement(By.ClassName("alert--warning"));
        public IWebElement ContactAddLogo => _driver.FindElement(By.ClassName("spc--top--xlrg"));
        public IWebElement EmailBanner => _driver.FindElement(By.XPath("//label[@for='email']"));
        public IWebElement UsernameBanner => _driver.FindElement(By.XPath("//baasic-registration//form/div[1]/div[2]/label"));
        public IWebElement PasswordBanner => _driver.FindElement(By.XPath("//baasic-registration//form/div[2]/div[1]/label"));
        public IWebElement ConfirmPasswordBanner => _driver.FindElement(By.XPath("//baasic-registration//form/div[2]/div[2]/label"));
    }
}