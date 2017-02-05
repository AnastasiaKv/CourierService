using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierServiceApp.Models
{
    public class PaymentOptionsModel
    {
        public double amt { get; set; }
        public string ccy { get; set; }
        public int merchant { get; set; }
        public string order { get; set; }
        public string details { get; set; }
        public string ext_details { get; set; }
        public string pay_way { get; set; }
        public string state { get; set; }
        public string data { get; set; }
        public string _ref { get; set; }
        public string payCountry { get; set; }
    }
}