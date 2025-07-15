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

        public IWebElement Logo => _driver.FindElement(By.CssSelector("a.navbar-brand img"));
        public IWebElement MenuDropdown => _driver.FindElement(By.CssSelector(".dropdown-menu"));
        public IWebElement MenuOverlay => _driver.FindElement(By.CssSelector(".menu-overlay, .modal-backdrop"));
        public IWebElement RegisterBanner => _driver.FindElement(By.XPath("//h1[contains(text(),'Register')]"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("email"));
        public IWebElement UsernameTextbox => _driver.FindElement(By.Id("username"));
        public IWebElement PasswordTextbox => _driver.FindElement(By.Id("password"));
        public IWebElement ConfirmPasswordTextbox => _driver.FindElement(By.Id("confirmPassword"));
        public IWebElement RegisterButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".alert-danger, .validation-summary-errors"));
        public IWebElement ContactAddLogo => _driver.FindElement(By.CssSelector(".fa-user-plus, .icon-contact-add"));
        public IWebElement EmailBanner => _driver.FindElement(By.XPath("//label[@for='email']"));
        public IWebElement UsernameBanner => _driver.FindElement(By.XPath("//label[@for='username']"));
        public IWebElement PasswordBanner => _driver.FindElement(By.XPath("//label[@for='password']"));
        public IWebElement ConfirmPasswordBanner => _driver.FindElement(By.XPath("//label[@for='confirmPassword']"));
    }
}