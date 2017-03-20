using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Volotea
{
    [TestFixture]
    public class UnitTest1
    {
        [Test][Ignore ("Check of framework configuration")]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://www.volotea.com/en");
                driver.Manage().Window.Maximize();
                var signInLink = driver.FindElement(By.XPath("//a[contains(@class,'switcherLogin')]"));
                var userNameField = driver.FindElement(By.XPath("//input[@id='emailLoginForm']"));
                var userPasswordField = driver.FindElement(By.XPath("//input[@id='passwordLoginForm']"));
                var loginButton = driver.FindElement(By.XPath("//a[contains(.,'Sign in')]"));

                signInLink.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                userNameField.SendKeys("l447557@mvrht.com");
                userPasswordField.SendKeys("123qwe");
                loginButton.Click();
            }
        }
    }
}
