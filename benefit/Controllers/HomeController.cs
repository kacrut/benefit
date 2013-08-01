using benefit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace benefit.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult RekapBenefitBU()
        {
            using (var db = new BENEFITContext())
            {
                return PartialView(db.vwRekapBuListInfoBenefits.ToList());
            }
        }

        public ActionResult RekapSettingBU()
        {
            using (var db = new BENEFITContext())
            {
                return PartialView(db.vwRekapBuListInfoSettings.ToList());
            }
        }


    }
}
