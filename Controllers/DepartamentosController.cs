using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SandyStoreWS;
using SandyStoreWS.Negocio;

namespace SandyStoreWS.Controllers
{
    public class DepartamentosController : ApiController
    {
        private TiendaCarvajalAPIEntities db = new TiendaCarvajalAPIEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/Departamentos
        public IHttpActionResult GetDepartamentos()
        {
            try
            {
                log.Debug("GetDepartamentos, api/Departamentos");
                DepartamentoNegocio departamentos = new DepartamentoNegocio();
                return Ok(departamentos.Departamentos());
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        //// GET: api/Departamentos/5
        //[ResponseType(typeof(Departamentos))]
        //public IHttpActionResult GetDepartamentos(int id)
        //{
        //    Departamentos departamentos = db.Departamentos.Find(id);
        //    if (departamentos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(departamentos);
        //}

        //// PUT: api/Departamentos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDepartamentos(int id, Departamentos departamentos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != departamentos.DepID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(departamentos).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartamentosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Departamentos
        //[ResponseType(typeof(Departamentos))]
        //public IHttpActionResult PostDepartamentos(Departamentos departamentos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Departamentos.Add(departamentos);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = departamentos.DepID }, departamentos);
        //}

        //// DELETE: api/Departamentos/5
        //[ResponseType(typeof(Departamentos))]
        //public IHttpActionResult DeleteDepartamentos(int id)
        //{
        //    Departamentos departamentos = db.Departamentos.Find(id);
        //    if (departamentos == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Departamentos.Remove(departamentos);
        //    db.SaveChanges();

        //    return Ok(departamentos);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DepartamentosExists(int id)
        //{
        //    return db.Departamentos.Count(e => e.DepID == id) > 0;
        //}
    }
}