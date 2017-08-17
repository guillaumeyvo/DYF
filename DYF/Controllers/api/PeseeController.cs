using DYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                DateTime date;
                if (db.Pesee.Any(p => p.IdRepartitionBande == idRepartitionBande))
                {
                    date = db.Pesee.OrderByDescending(o => o.Date).FirstOrDefault(p => p.IdRepartitionBande == idRepartitionBande).Date;
                    return Ok(new { year = date.Year, month = date.Month, day = date.Day });
                }
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}
