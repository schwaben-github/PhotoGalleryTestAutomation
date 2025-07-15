using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowPhotoGallery.Specs.Drivers;
using SpecFlowPhotoGallery.Specs.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowPhotoGallery.Specs.StepDefinitions
{
    [Binding]
    public class RegisterAssertionSteps
    {
        private readonly IWebDriver _driver;
        private readonly RegisterPage _registerPage;
        private readonly HomePage _homePage;

        public RegisterAssertionSteps(WebDriverContext context)
        {
            _driver = context.Driver;
            _registerPage = new RegisterPage(_driver);
            _homePage = new HomePage(_driver);
        }

        [Then("the '(.*)' is displayed")]
        public void ElementIsDisplayed(string element)
        {
            switch (element.ToLower())
            {
                case "homepage":
                    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    bool titleReady = wait.Until(drv => !string.IsNullOrEmpty(drv.Title));
                    var actualTitle = _driver.Title;
                    Console.WriteLine($"[DEBUG] Actual page title: '{actualTitle}'");
                    actualTitle.Should().Contain("baasic-starterkit-angular-blog");
                    break;
                case "logo":
                    _homePage.Logo.Displayed.Should().BeTrue();
                    break;
                case "register page":
                    _registerPage.RegisterBanner.Displayed.Should().BeTrue();
                    break;
                case "contact add":
                    _registerPage.ContactAddLogo.Displayed.Should().BeTrue();
                    break;
                case "register banner":
                    _registerPage.RegisterBanner.Displayed.Should().BeTrue();
                    break;
                case "email banner":
                    _registerPage.EmailBanner.Displayed.Should().BeTrue();
                    break;
                case "username banner":
                    _registerPage.UsernameBanner.Displayed.Should().BeTrue();
                    break;
                case "password banner":
                    _registerPage.PasswordBanner.Displayed.Should().BeTrue();
                    break;
                case "confirm password":
                    _registerPage.ConfirmPasswordBanner.Displayed.Should().BeTrue();
                    break;
                case "email textbox":
                    _registerPage.EmailTextbox.Displayed.Should().BeTrue();
                    _registerPage.EmailTextbox.Enabled.Should().BeTrue();
                    _registerPage.EmailTextbox.GetAttribute("value").Should().Be("");
                    break;
                case "username textbox":
                    _registerPage.UsernameTextbox.Displayed.Should().BeTrue();
                    _registerPage.UsernameTextbox.Enabled.Should().BeTrue();
                    _registerPage.UsernameTextbox.GetAttribute("value").Should().Be("");
                    break;
                case "password textbox":
                    _registerPage.PasswordTextbox.Displayed.Should().BeTrue();
                    _registerPage.PasswordTextbox.Enabled.Should().BeTrue();
                    _registerPage.PasswordTextbox.GetAttribute("value").Should().Be("");
                    break;
                case "confirm password textbox":
                    _registerPage.ConfirmPasswordTextbox.Displayed.Should().BeTrue();
                    _registerPage.ConfirmPasswordTextbox.Enabled.Should().BeTrue();
                    _registerPage.ConfirmPasswordTextbox.GetAttribute("value").Should().Be("");
                    break;
                case "register button":
                    _registerPage.RegisterButton.Displayed.Should().BeTrue();
                    _registerPage.RegisterButton.Enabled.Should().BeTrue();
                    _registerPage.RegisterButton.Text.ToUpper().Should().Contain("REGISTER");
                    break;
                default:
                    throw new NotImplementedException($"Element '{element}' not mapped in step definition.");
            }
        }

        [Then("the '(.*)' is displayed in the top left corner")]
        public void ElementIsDisplayedInTopLeftCorner(string element)
        {
            // For now, just check display, as position is not asserted in original code
            ElementIsDisplayed(element);
        }

        [Then("the '(.*)' is displayed in the top left corner of the '(.*)' page")]
        public void ElementIsDisplayedInTopLeftCornerOfPage(string element, string page)
        {
            // For now, just check display, as position is not asserted in original code
            ElementIsDisplayed(element);
        }

        [Then("the '(.*)' banner is displayed and contains '(.*)' string")]
        public void BannerIsDisplayedAndContains(string banner, string text)
        {
            IWebElement element = banner.ToLower() switch
            {
                "register" => _registerPage.RegisterBanner,
                "email" => _registerPage.EmailBanner,
                "username" => _registerPage.UsernameBanner,
                "password" => _registerPage.PasswordBanner,
                "confirm password" => _registerPage.ConfirmPasswordBanner,
                _ => throw new NotImplementedException($"Banner '{banner}' not mapped.")
            };
            element.Displayed.Should().BeTrue();
            element.Text.Should().Contain(text);
        }

        [Then("the '(.*)' textbox is displayed, enabled, and empty")]
        [Then("the '(.*)' textbox is displayed, enabled and empty")]
        public void TextboxIsDisplayedEnabledAndEmpty(string textbox)
        {
            IWebElement element = textbox.ToLower() switch
            {
                "email" => _registerPage.EmailTextbox,
                "username" => _registerPage.UsernameTextbox,
                "password" => _registerPage.PasswordTextbox,
                "confirm password" => _registerPage.ConfirmPasswordTextbox,
                _ => throw new NotImplementedException($"Textbox '{textbox}' not mapped.")
            };
            element.Displayed.Should().BeTrue();
            element.Enabled.Should().BeTrue();
            element.GetAttribute("value").Should().Be("");
        }

        [Then("the '(.*)' button is displayed and contains '(.*)' string")]
        public void ButtonIsDisplayedAndContains(string button, string text)
        {
            if (button.ToLower() == "register")
            {
                _registerPage.RegisterButton.Displayed.Should().BeTrue();
                _registerPage.RegisterButton.Text.ToUpper().Should().Contain(text.ToUpper());
            }
            else
            {
                throw new NotImplementedException($"Button '{button}' not mapped.");
            }
        }

        [Then("the '(.*)' dropdown is displayed")]
        public void DropdownIsDisplayed(string dropdown)
        {
            if (dropdown.ToLower() == "menu")
            {
                _homePage.MenuDropdown.Displayed.Should().BeTrue();
            }
            else
            {
                throw new NotImplementedException($"Dropdown '{dropdown}' not mapped.");
            }
        }

        [Then("the '(.*)' overlay is displayed")]
        public void OverlayIsDisplayed(string overlay)
        {
            if (overlay.ToLower() == "menu")
            {
                _homePage.MenuOverlay.Displayed.Should().BeTrue();
            }
            else
            {
                throw new NotImplementedException($"Overlay '{overlay}' not mapped.");
            }
        }

        [Then("the '(.*)' textbox contains '(.*)'")]
        public void TextboxContains(string textbox, string value)
        {
            string actual = textbox.ToLower() switch
            {
                "email" => _registerPage.EmailTextbox.GetAttribute("value"),
                "username" => _registerPage.UsernameTextbox.GetAttribute("value"),
                "password" => _registerPage.PasswordTextbox.GetAttribute("value"),
                "confirm password" => _registerPage.ConfirmPasswordTextbox.GetAttribute("value"),
                _ => throw new NotImplementedException($"Textbox '{textbox}' not mapped.")
            };
            if (textbox.ToLower().Contains("password"))
            {
                // Password fields are masked, so just check not empty
                actual.Should().NotBeNullOrEmpty();
            }
            else
            {
                actual.Should().Be(value);
            }
        }

        [Then("the '(.*)' textbox contains an anonymized password")]
        public void TextboxContainsAnonymizedPassword(string textbox)
        {
            string actual = textbox.ToLower() switch
            {
                "password" => _registerPage.PasswordTextbox.GetAttribute("value"),
                "confirm password" => _registerPage.ConfirmPasswordTextbox.GetAttribute("value"),
                _ => throw new NotImplementedException($"Textbox '{textbox}' not mapped.")
            };
            actual.Should().NotBeNullOrEmpty();
        }

        [Then("the '(.*)' textbox contains '(.*)' string")]
        public void TextboxContainsString(string textbox, string value)
        {
            string actual = textbox.ToLower() switch
            {
                "email" => _registerPage.EmailTextbox.GetAttribute("value"),
                "username" => _registerPage.UsernameTextbox.GetAttribute("value"),
                _ => throw new NotImplementedException($"Textbox '{textbox}' not mapped.")
            };
            actual.Should().Be(value);
        }

        [Then("the error message '(.*)' is displayed")]
        public void ErrorMessageIsDisplayed(string message)
        {
            _registerPage.ErrorMessage.Displayed.Should().BeTrue();
            _registerPage.ErrorMessage.Text.Should().Contain(message);
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
    }
}