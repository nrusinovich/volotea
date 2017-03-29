using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class LoginPage
    {
        private string baseUrl = "http://www.volotea.com/en";
        private string singInLinkXPath = "//a[@class = 'switcherLogin']";
        private string loginInputXPath = "//input[@id = 'emailLoginForm']";
        private string passInputXPath = "//input[@id = 'passwordLoginForm']";
        private string singInButtonXPath = "//form[@id = 'loginForm']//a[contains(text(), 'Sign in')]";
        private string login = "l447557@mvrht.com";
        private string pass = "123qwe";
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage LogiIn(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl);
            WebElementHelper.WaitAndClick(driver, By.XPath(singInLinkXPath));
            WebElementHelper.WaitAndSendKeys(driver, By.XPath(loginInputXPath), login);
            WebElementHelper.WaitAndSendKeys(driver, By.XPath(passInputXPath), pass);
            WebElementHelper.WaitAndClick(driver, By.XPath(singInButtonXPath));
            return new MainPage(driver);
        }
    }
}