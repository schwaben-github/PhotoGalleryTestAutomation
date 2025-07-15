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

        public IWebElement Logo => _driver.FindElement(By.ClassName("menu"));
        public IWebElement MenuDropdown => _driver.FindElement(By.XPath("//baasic-header//a/a"));
        public IWebElement MenuLink => _driver.FindElement(By.LinkText("MENU"));
        public IWebElement MenuOverlay => _driver.FindElement(By.ClassName("nav__wrapper"));
        public IWebElement RegisterLink => _driver.FindElement(By.XPath("//li[contains(@class,'nav__item')]/span[contains(@class,'nav__link') and text()='Register']"));
        public IWebElement HomeBanner => _driver.FindElement(By.XPath("//home-route//cover/div[2]/div/p"));
        public IWebElement SearchTextbox => _driver.FindElement(By.Name("search"));
    }
}