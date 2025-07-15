using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SpecFlowPhotoGallery.Specs.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPhotoGallery.Specss.StepDefinitions
{
    [Binding]
    public class RegisterActionSteps : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _registerPage;

        public RegisterActionSteps()
        {
            _driver = new ChromeDriver();
            _registerPage = new RegisterPage(_driver);
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
                actions.MoveToElement(_registerPage.Logo).Perform();
                Thread.Sleep(500); // Wait for dropdown to appear
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
            link.Click();
            Thread.Sleep(500); // Wait for navigation/overlay
        }

        [When("I enter '(.*)' into the '(.*)' textbox")]
        public void EnterIntoTheTextbox(string value, string textbox)
        {
            switch (textbox.ToLower())
            {
                case "email":
                    _registerPage.EmailTextbox.Clear();
                    _registerPage.EmailTextbox.SendKeys(value);
                    break;
                case "username":
                    _registerPage.UsernameTextbox.Clear();
                    _registerPage.UsernameTextbox.SendKeys(value);
                    break;
                case "password":
                    _registerPage.PasswordTextbox.Clear();
                    _registerPage.PasswordTextbox.SendKeys(value);
                    break;
                case "confirm password":
                    _registerPage.ConfirmPasswordTextbox.Clear();
                    _registerPage.ConfirmPasswordTextbox.SendKeys(value);
                    break;
                default:
                    throw new NotImplementedException($"Textbox '{textbox}' not mapped.");
            }
        }

        [When("I click the '(.*)' button")]
        public void ClickTheButton(string button)
        {
            if (button.ToLower() == "register")
            {
                _registerPage.RegisterButton.Click();
                Thread.Sleep(500); // Wait for error message
            }
            else
            {
                throw new NotImplementedException($"Button '{button}' not mapped.");
            }
        }

        [When("I click on the 'Register' button")]
        public void ClickOnTheRegisterButton()
        {
            _registerPage.RegisterButton.Click();
            Thread.Sleep(500); // Wait for error message or navigation
        }

        [Then("the 'Register' page is displayed")]
        public void RegisterPageIsDisplayed()
        {
            if (!_registerPage.RegisterBanner.Displayed)
                throw new Exception("Register page is not displayed.");
        }

        [Then("the 'Contact add' logo is displayed")]
        public void ContactAddLogoIsDisplayed()
        {
            if (!_registerPage.ContactAddLogo.Displayed)
                throw new Exception("Contact add logo is not displayed.");
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}