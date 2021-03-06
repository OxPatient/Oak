﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oak;
using Massive;
using Peeps.Repositories;

namespace Peeps.Controllers
{
    public class HomeController : Controller
    {
        People people = new People();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return new DynamicJsonResult(people.All());
        }

        [HttpPost]
        public ActionResult Update(dynamic @params)
        {
            if (@params.RespondsTo("Id")) people.Save(@params);

            else @params.Id = people.Insert(@params);

            return new DynamicJsonResult(@params);
        }

        [HttpPost]
        public ActionResult UpdateAll(dynamic @params)
        {
            people.Save(@params.Items);

            return new EmptyResult();
        }
    }
}
