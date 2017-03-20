using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volotea.Utils
{
    class Hotel
    {
        public Hotel() { }
        private string price;

        public string GetPrice()
        {
            return price;
        }

        public void SetPrice(string price)
        {
            this.price = price;
        }
    }
}
