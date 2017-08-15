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

        public IHttpActionResult RepartitionBande(int idBande)
        {
            try
            {
                IEnumerable<RepartitionBande> liste = db.RepartitionBande.Where(r => r.IdBande == idBande);
                return Ok(liste);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        [HttpGet]
        public IHttpActionResult RepartitionBande()
        {
            try
            {
                IEnumerable<RepartitionBande> liste = db.RepartitionBande.Where(r => r.IdBande == 1);
                return Ok(liste);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }
    }
}
