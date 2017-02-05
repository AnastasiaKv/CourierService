using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBModel.Entities;

namespace CourierServiceApp.Areas.Manager.Models
{
    public class ManagmentModel
    {
        public IEnumerable<Order>  Orders{ get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<LuggageType> LuggageTypes { get; set; }
        public IEnumerable<CourierTransportType> CourierTransportTypes { get; set; }
        public IEnumerable<OrderItem> CouriersOrders { get; set; }

    }
}