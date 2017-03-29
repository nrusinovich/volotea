﻿using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Volotea
{
    public class WebDriver
    {
        public static IWebDriver GetBrowser(string browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case "firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "chrome":

                    if (driver == null)
                    {
                        driver = new ChromeDriver();
                    }
                    break;

                case "browserstack":

                    if (driver == null)
                    {
                        DesiredCapabilities capability = DesiredCapabilities.Firefox();
                        capability.SetCapability("browserstack.user", "yahorstaravoitau1");
                        capability.SetCapability("browserstack.key", "zgPPQ2ozWfWqqn2ryMu4");
                        capability.SetCapability("browser", "Safari");
                        capability.SetCapability("browser_version", "10.0");
                        capability.SetCapability("os", "OS X");
                        capability.SetCapability("os_version", "Sierra");
                        capability.SetCapability("resolution", "1024x768");
                        driver = new RemoteWebDriver(
                        new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
                        );
                    }
                    break;

                case "saucelabs":
                    if (driver == null)
                    {
                        DesiredCapabilities capability = new DesiredCapabilities();
                        capability.SetCapability(CapabilityType.BrowserName, "chrome");
                        capability.SetCapability(CapabilityType.Version, "31");
                        capability.SetCapability(CapabilityType.Platform, "Mac OS X 10.9");
                        capability.SetCapability("username", "YahorStaravoitau");
                        capability.SetCapability("accessKey", "91ef5c5b-44e2-4ee6-8696-0548dfba061d");

                        driver = new RemoteWebDriver(
                            new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capability,
                            TimeSpan.FromSeconds(600));
                    }
                    break;

                case "chrome-without-popups":
                    if (driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--start-maximized");
                        //options.AddArguments("--disable-javascript");
                        //options.AddArguments("test-type");
                        options.AddArguments("--enable-popup-blocking");
                        options.ToCapabilities();
                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                        driver = new ChromeDriver(service, options);
                    }
                    break;
            }
            return driver;
        }
    }
}
