using OpenQA.Selenium;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingForthStepPage
    {
        private IWebDriver driver;
        private string seatsCheckBoxXPath = "//span[@id = 'ifYouDontChooseSeat']";
        private string bagsCheckBoxXPath = "//p[contains(text(), 'No, I will only take carry-on luggage')]";
        private string flexCheckBoxXPath = "//p[contains(text(), 'No, I am sure that I will not change my plans')]";
        private string insuranceCheckBoxXPath = "//p[contains(text(), 'No, I want to travel without insurance')]";
        private string checkInCheckBoxXPath = "//p[contains(text(), 'No, check-in online')]";
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";


        public BookingForthStepPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PaymentStepPage NextStep(IWebDriver driver)
        {
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(seatsCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(bagsCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(flexCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(insuranceCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(checkInCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(driver, By.XPath(nextStepButtonXPath));
            return new PaymentStepPage(driver);
        }
    }
}