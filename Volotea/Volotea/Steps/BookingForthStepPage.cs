﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using Volotea.Utils;

namespace Volotea.Steps
{
    public class BookingForthStepPage : BasePage
    {
        private string seatsCheckBoxXPath = "//span[@id = 'ifYouDontChooseSeat']";
        private string bagsCheckBoxXPath = "//p[contains(text(), 'No, I will only take carry-on luggage')]";
        private string flexCheckBoxXPath = "//p[contains(text(), 'No, I am sure that I will not change my plans')]";
        private string insuranceCheckBoxXPath = "//p[contains(text(), 'No, I want to travel without insurance')]";
        private string checkInCheckBoxXPath = "//p[contains(text(), 'No, check-in online')]";
        private string nextStepButtonXPath = "//a[contains(text(), 'NEXT STEP')]";

        public BookingForthStepPage(BasePage bp) : base(bp)
        {
        }

        public PaymentStepPage NextStep(BasePage bp)
        {
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(seatsCheckBoxXPath));
            Thread.Sleep(1000);
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(bagsCheckBoxXPath));
            Thread.Sleep(1000);
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(flexCheckBoxXPath));
            //Thread.Sleep(1000);
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(insuranceCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(checkInCheckBoxXPath));
            WebElementHelper.MoveToElementAndClick(Driver, By.XPath(nextStepButtonXPath));
            return new PaymentStepPage(bp);
        }
    }
}