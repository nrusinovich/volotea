using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volotea.Utils;

namespace Volotea.Steps
{
    class HotelsPage : BasePage
    {
        public HotelsPage(string browser) : base(browser)
        {
        }
        public string lowestPrice;
        private static string tmpDay = DateTime.Now.Day.ToString();
        private By dayLocator = By.XPath(string.Format("//span[@class = 'c2-day-inner' and contains(text(), {0})]", tmpDay));

        private By cityInputLocator = By.XPath("//input[contains(@placeholder, 'but you can try!')]");//"//input[@class = 'c-autocomplete__input sb-searchbox__input sb-destination__input sb-autocomplete__input-two-lines']");
        private By confirmCityLocator = By.XPath("//b[@class = 'search_hl_name']");//"//li[@data-i = '0']");
        private By checkInDateLocator = By.XPath("//div[@data-placeholder = 'Check-in Date']");

        //private By monthLocator = By.XPath("//div[@class = 'c2-months-table']");
        //private By tempMonthLocator = By.XPath("//div[@data-offset = '0']");
        private By tmpDayLocator = By.XPath("//td[contains(@class, 'c2-day c2-day-s-today c2-day-s-in-range c2-day-s-first-in-range')]");

        private By letsGoButtonLocator = By.XPath("//span[@class = 'b-button__text']");
        private By allHotelsLocator = By.XPath("//div[contains(@class, 'sr_item sr_item_new') and not(contains(@class, 'soldout_property'))][../@id = 'hotellist_inner']");//"//div[@id = 'hotellist_inner']");
        private By hotelPriceLocator = By.XPath("//strong[contains(@class, ' price scarcity_color')]");//"//b[contains(text(), 'BYN ')]");//"//strong[contains(@class, ' price availprice  no_rack_rate')]");
        private By hotelNameLocator = By.XPath("//span[@class = 'sr-hotel__name']");
        private By actualPriceLocator = By.XPath("//strong[contains(@class, ' b-tooltip-with-price-breakdown-tracker   rooms-table-room-price red-actual-rack-rate')]");//"//strong[contains(@data-price-without-addons, 'BYN')]");

        public IWebElement CityInput
        {
            get { return Driver.FindElement(cityInputLocator); }
        }
       
        public IWebElement ConfirmCity
        {
            get { return Driver.FindElement(confirmCityLocator); }
        }

        public IWebElement CheckInDate
        {
            get { return Driver.FindElement(checkInDateLocator); }
        }
        public IWebElement Day
        {
            get { return Driver.FindElement(dayLocator); }
        }

        public IWebElement LetsGoButton
        {
            get { return Driver.FindElement(letsGoButtonLocator); }
        }

        public IEnumerable<IWebElement> AllHotels
        {
            get { return Driver.FindElements(allHotelsLocator); }
        }

        public IWebElement HotelPrice
        {
            get { return Driver.FindElement(hotelPriceLocator); }
        }

        public IWebElement HotelName
        {
            get { return Driver.FindElement(hotelNameLocator); }
        }

        public IWebElement ActualPrice
        {
            get { return Driver.FindElement(actualPriceLocator); }
        }

        public string LowestPrice
        {
            get { return this.lowestPrice; }
            set { this.lowestPrice = value; }
        }

        public void FindHotels()
        {
            Thread.Sleep(1000);
            WaitAndClick(CityInput);
            CityInput.SendKeys("Venice");
            Thread.Sleep(3000);
            WaitAndClick(ConfirmCity);          
            WaitAndClick(CheckInDate);
            WaitAndClick(CheckInDate);
            WaitAndClick(Day);
            WaitAndClick(LetsGoButton);
        }

        public void FindCheapestHotelAndGo()
        {
            Thread.Sleep(6000);
            int minPrice = 9999999;
            int hotelPrice = 0;
            IWebElement cheapestHotel = null;
            foreach (var hotel in AllHotels)
            {
                MoveCursorToElement(hotel);
                By someHotelPriceLocator = hotelPriceLocator;
                if(hotel.FindElement(hotelPriceLocator).Enabled == false)
                {
                    someHotelPriceLocator = By.XPath("//strong[contains(@class, 'price availprice  no_rack_rate')]");
                }                       
                        //var somehotelPrice = hotel.FindElement(hotelPriceLocator);

                        //hotelPriceLocator = By.XPath("//strong[contains(@class, 'price availprice  no_rack_rate')]");
                    hotelPrice = Int32.Parse(hotel.FindElement(someHotelPriceLocator).Text.Replace("BYN ", ""));
                    if (minPrice > hotelPrice)
                    {
                        minPrice = hotelPrice;
                        cheapestHotel = hotel;
                    }
                
            }
            LowestPrice = minPrice.ToString();//cheapestHotel.FindElement(hotelPriceLocator).Text.Replace("BYN ", "");
            WaitAndClick(cheapestHotel.FindElement(hotelNameLocator));                        
        }

        public string GetActualPrice()
        {
            SwitchToLastTab();
            MoveCursorToElement(ActualPrice);       
            return ActualPrice.Text.Replace("BYN ", "");           
        }
    }
}
