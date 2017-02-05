using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierServiceApp.Models
{
    public class MenuItemModel
    {
        public string currentController { get; set; }
        public string currentAction { get; set; }

        public MenuItemModel()
        {
                
        }
    }
}