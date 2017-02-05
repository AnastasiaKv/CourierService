using CourierServiceApp.Areas.Manager.Models;
using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierServiceApp.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Manager/Home
        public ActionResult Index()
        {
            var model = new ManagmentModel();
            model.Orders = DBManager.UnitOfWork.OrderRepository.Get();
            model.Statuses = DBManager.UnitOfWork.StatusRepository.Get();
            
            return View(model);
        }
        public ActionResult CourierManagment(Guid id)
        {
            var model = new ManagmentModel();
            model.LuggageTypes = DBManager.UnitOfWork.LuggageTypeRepository.Get();
            model.CourierTransportTypes = DBManager.UnitOfWork.CourierTransportTypeRepository.Get();
            model.OrderItems = DBManager.UnitOfWork.OrderItemRepository.Get();
            

            if (id != Guid.Empty)
            {
                model.CouriersOrders = model.OrderItems.Where(o => o.CourierID == id);
            }
            
            return View(model);
        }
    }
}