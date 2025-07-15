using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowPhotoGallery.Specs.Drivers;
using SpecFlowPhotoGallery.Specs.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPhotoGallery.Specss.StepDefinitions
{
    [Binding]
    public class RegisterActionSteps
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _registerPage;
        private readonly HomePage _homePage;

        public RegisterActionSteps(WebDriverContext context)
        {
            _driver = context.Driver;
            _registerPage = new RegisterPage(_driver);
            _homePage = new HomePage(_driver);
        }

        [Given("I open the start page")]
        [When("I open the start page")]
        public void OpenStartPage()
        {
            _driver.Navigate().GoToUrl("https://demo.baasic.com/angular/starterkit-photo-gallery/main");
        }

        [When("I hover over the '(.*)'")]
        public void HoverOverTheElement(string element)
        {
            if (element.ToLower() == "logo")
            {
                var actions = new Actions(_driver);
                actions.MoveToElement(_homePage.Logo).Perform();
                Thread.Sleep(500);
            }
            else
            {
                throw new NotImplementedException($"Hover for '{element}' not implemented.");
            }
        }

        [When("I click on the '(.*)' link")]
        public void ClickOnTheLink(string linkText)
        {
            var link = _driver.FindElement(By.LinkText(linkText));
            Thread.Sleep(500);
            link.Click();
            Thread.Sleep(500);
        }

        [When("I click on the Register link")]
        public void ClickOnTheRegisterLink()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Console.WriteLine("[DEBUG] Waiting for Register link to be visible and enabled...");
            wait.Until(_ => _homePage.RegisterLink.Displayed && _homePage.RegisterLink.Enabled);
            var registerLink = _homePage.RegisterLink;
            Console.WriteLine("[DEBUG] Register link found. Attempting to click...");
            var actions = new Actions(_driver);
            actions.MoveToElement(registerLink).Click().Perform();
            Console.WriteLine("[DEBUG] Register link clicked.");
            Thread.Sleep(500);
        }

        [When("I enter '(.*)' into the '(.*)' textbox")]
        public void EnterIntoTheTextbox(string value, string textbox)
        {
            IWebElement element = null;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            switch (textbox.ToLower())
            {
                case "email":
                    wait.Until(_ => _registerPage.EmailTextbox.Displayed && _registerPage.EmailTextbox.Enabled);
                    element = _registerPage.EmailTextbox;
                    break;
                case "username":
                    wait.Until(_ => _registerPage.UsernameTextbox.Displayed && _registerPage.UsernameTextbox.Enabled);
                    element = _registerPage.UsernameTextbox;
                    break;
                case "password":
                    wait.Until(_ => _registerPage.PasswordTextbox.Displayed && _registerPage.PasswordTextbox.Enabled);
                    element = _registerPage.PasswordTextbox;
                    break;
                case "confirm password":
                    wait.Until(_ => _registerPage.ConfirmPasswordTextbox.Displayed && _registerPage.ConfirmPasswordTextbox.Enabled);
                    element = _registerPage.ConfirmPasswordTextbox;
                    break;
                default:
                    throw new NotImplementedException($"Textbox '{textbox}' not mapped.");
            }
            Console.WriteLine($"[DEBUG] Before: '{textbox}' Displayed={element.Displayed}, Enabled={element.Enabled}, Value='{element.GetAttribute("value")}'");
            try
            {
                element.Click();
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(value);
                Thread.Sleep(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DEBUG] SendKeys failed: {ex.Message}. Trying JavaScript set value.");
                var js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript($@"
                    var input = arguments[0];
                    input.value = '{value}';
                    input.dispatchEvent(new Event('input', {{ bubbles: true }}));
                    input.dispatchEvent(new Event('change', {{ bubbles: true }}));
                ", element);
                Thread.Sleep(200);
            }
            Console.WriteLine($"[DEBUG] After: '{textbox}' Value='{element.GetAttribute("value")}'");
        }

        [When("I click the '(.*)' button")]
        public void ClickTheButton(string button)
        {
            if (button.ToLower() == "register")
            {
                _registerPage.RegisterButton.Click();
                Thread.Sleep(500);
            }
            else
            {
                throw new NotImplementedException($"Button '{button}' not mapped.");
            }
        }

        [When("I click on the Register button")]
        public void ClickOnTheRegisterButton()
        {
            _registerPage.RegisterButton.Click();
        }
    }
}