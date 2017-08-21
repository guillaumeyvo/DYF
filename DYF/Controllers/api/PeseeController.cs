using DYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DYF.Controllers.api
{
    public class PeseeController : ApiController
    {
        private DyfContext db;
        public PeseeController()
        {
            db = new DyfContext();
        }
        [HttpGet]

        public IHttpActionResult GetRepartitionBande(int idBande)
        {
            try
            {
                var liste = db.RepartitionBande.Where(r => r.IdBande == idBande).Select(p => new { value = p.Id, text = p.Nom});
                return Ok(liste);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpGet]
        public IHttpActionResult GetPeseeLastDate(int idRepartitionBande)
        {
            try
            {
                DateTime dateDernierePesee;
                DateTime dateArriveBande = db.RepartitionBande.FirstOrDefault(r => r.Id == idRepartitionBande).Bande.DateArrivee;
                if (db.Pesee.Count(p => p.IdRepartitionBande == idRepartitionBande) > 0)
                {
                    dateDernierePesee = db.Pesee.OrderByDescending(o => o.Date).FirstOrDefault(p => p.IdRepartitionBande == idRepartitionBande).Date;
                    return Ok(new { year = dateDernierePesee.Year, month = dateDernierePesee.Month, day = dateDernierePesee.Day });
                }
                return Ok(new { year = dateArriveBande.Year, month = dateArriveBande.Month, day = dateArriveBande.Day});
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpPost]
        public IHttpActionResult SavePesee()
        {
            var poidsData = HttpContext.Current.Request.Form["poidsData"];
            var sujetsData = HttpContext.Current.Request.Form["sujetsData"];
            var totalPoids = HttpContext.Current.Request.Form["totalPoids"];
            var poidsMoyen = HttpContext.Current.Request.Form["poidsMoyen"];
            var homogeneite = HttpContext.Current.Request.Form["homogeneite"];
            var nombreDeSujetsPeses = HttpContext.Current.Request.Form["nombreDeSujetsPeses"];
            var idRepartitionBande = HttpContext.Current.Request.Form["idRepartitionBande"];
            var idBande = HttpContext.Current.Request.Form["idBande"];
            var datePesee = HttpContext.Current.Request.Form["datePesee"];
            var ageDesSujetEnSemaine = HttpContext.Current.Request.Form["ageDesSujetEnSemaine"];
            var idTypePesee = HttpContext.Current.Request.Form["idTypePesee"];

            string[] dateArray = datePesee.Split('/');

            Pesee Pesee = new Pesee
            {
                AgeDesSujetEnSemaine = Convert.ToInt32(ageDesSujetEnSemaine),
                Date = new DateTime(Convert.ToInt32(dateArray[0]), Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[2])),
                Homogeneite = Convert.ToDouble(homogeneite),
                NombreDeSujetsPeses = Convert.ToInt32(nombreDeSujetsPeses),
                IdRepartitionBande = Convert.ToInt32(idRepartitionBande),
                PoidsMoyen = Convert.ToDouble(poidsMoyen),
                IdTypePesee = Convert.ToInt32(idTypePesee),
            };

            db.Pesee.Add(Pesee);

            List<DetailsPesee> DetailsPesee = new List<DetailsPesee>();

            string[] arrayPoids = poidsData.Split(';');
            string[] arraySujets = sujetsData.Split(';');

            for (int i = 0; i < arrayPoids.Length; i++)
            {
                DetailsPesee.Add(new DetailsPesee
                {
                    NombreDeSujets = Convert.ToInt32(arraySujets[i]),
                    Poids = Convert.ToInt32(arrayPoids[i]),
                    Pesee = Pesee
                });
            }

            foreach (var item in DetailsPesee)
            {
                db.DetailsPesee.Add(item);
            }

            db.SaveChanges();

            return Ok();
        }
    }
}
