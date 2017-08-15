using DYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DYF.CustomAttribute;

namespace DYF.Controllers
{
    [TrackUrlDetails]
    public class PeseeController : Controller
    {
        private DyfContext db;
        public PeseeController()
        {
            db = new DyfContext();
        }
        // GET: Pesee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NouvellePesee()
        {
            IEnumerable<Bande> ListeDesBandes = db.Bande;
            return View(ListeDesBandes);
        }

        public ActionResult Wizard()
        {
            return View();
        }
    }
}