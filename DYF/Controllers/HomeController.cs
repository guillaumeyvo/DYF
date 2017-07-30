using DYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //using (DyfContext db = new DyfContext())
            //{
            //    HistoriqueUtilisationProduit h = db.HistoriqueUtilisationProduit.Where(h => h.id)
            //}
            return View();
        }
    }
}
