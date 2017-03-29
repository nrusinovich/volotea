using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Steps
{
    public class LoginElement : BasePage
    {
        private By signInLocator = By.XPath("//a[@class='switcherLogin']");
        private By usernameFieldLocator = By.XPath("//input[@id='emailLoginForm']");
        private By userpasswordFieldLocator = By.XPath("//input[@id='passwordLoginForm']");
        private By loginButtonLocator = By.XPath("//a[contains(@class,'button sm block voloteaButton color1 alternateFont submitAnchor')]");
        private By rememberLoginLocator = By.XPath("//ins[@class='iCheck-helper']");
        private By yourProfileLocator = By.XPath("//a[@class='switcherProfileResume']");

        public LoginElement(string browser) : base(browser)
        {
        
        }

        public IWebElement SignInElement
        {
            get { return Driver.FindElement(signInLocator); }
        }

        public IWebElement UsernameFieldElement
        {
            get { return Driver.FindElement(usernameFieldLocator); }
        }

        public IWebElement UserpasswordElement
        {
            get { return Driver.FindElement(userpasswordFieldLocator); }
        }

        public IWebElement LoginButtonElement
        {
            get { return Driver.FindElement(loginButtonLocator); }
        }

        public IWebElement RememberLoginElement
        {
            get { return Driver.FindElement(rememberLoginLocator); }
        }

        public IWebElement YourProfileElement
        {
            get { return Driver.FindElement(yourProfileLocator); }
        }

        public void SignIn(string username, string password)
        {
            SignInElement.Click();
            this.WaitUntilDisplayed(UsernameFieldElement);
            this.WaitUntilDisplayed(UserpasswordElement);

            this.FillFields(username, password);
            RememberLoginElement.Click();
            LoginButtonElement.Click();
        }

        private void FillFields(string username, string password)
        {
            UsernameFieldElement.SendKeys(username);
            UserpasswordElement.SendKeys(password);
        }

        public string GetUserSurname()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(yourProfileLocator));
            return YourProfileElement.Text;
        }

        public MainPage SignIn(BasePage bp, string username, string password)
        {
            SignInElement.Click();
            this.WaitUntilDisplayed(UsernameFieldElement);
            this.WaitUntilDisplayed(UserpasswordElement);
            this.FillFields(username, password);
            RememberLoginElement.Click();
            LoginButtonElement.Click();
            return new MainPage(bp);
        }
    }
}
