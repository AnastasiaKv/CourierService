﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourierServiceApp.Controllers
{
    public class UserProfileController : BaseController
    {
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}