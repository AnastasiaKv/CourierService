using CourierServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierServiceApp.Controllers
{
    public class OrderCreateController : BaseController
    {
        // GET: OrderCreate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentCallBack(PaymentOptionsModel payment)
        {

            var model = new PaymentOptionsModel()
            {
                amt = payment.amt,
                ccy = payment.ccy,
                merchant = payment.merchant,
                order = payment.order,
                details = payment.details,
                ext_details = payment.ext_details,
                pay_way = payment.pay_way,
                data = payment.data,
                state = payment.state,
                _ref = payment._ref,
                payCountry = payment.payCountry
            };

            if (model.state == "ok")
                return View("Checkout");
            if (model.state == "fail")
                return View("Checkout");
            if (model.state == "test")
                return View("Checkout");
            if (model.state == "wait")
                return View("Checkout");

            return View("Checkout");
        }
    }
}