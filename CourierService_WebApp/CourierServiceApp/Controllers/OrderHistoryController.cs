using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierServiceApp.Controllers
{
    public class OrderHistoryController : BaseController
    {
        // GET: OrderHistory
        public ActionResult Index()
        {
            return View();
        }
    }
}