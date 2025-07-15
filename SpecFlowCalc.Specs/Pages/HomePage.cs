using OpenQA.Selenium;

namespace SpecFlowPhotoGallery.Specs.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Logo => _driver.FindElement(By.CssSelector("a.navbar-brand img"));
        public IWebElement MenuLink => _driver.FindElement(By.LinkText("MENU"));
        public IWebElement RegisterLink => _driver.FindElement(By.LinkText("Register"));
        public IWebElement HomeBanner => _driver.FindElement(By.CssSelector(".jumbotron h1, .main-banner h1, h1"));
        public IWebElement SearchResultLogo => _driver.FindElement(By.CssSelector(".search-result-logo, .fa-search, .icon-search"));
    }
}