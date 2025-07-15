using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowPhotoGallery.Specs.Drivers
{
    public class WebDriverContext : IDisposable
    {
        public IWebDriver Driver { get; }

        public WebDriverContext()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
