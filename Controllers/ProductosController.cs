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
using SandyStoreWS.Clases;
using SandyStoreWS.Models;

namespace SandyStoreWS.Controllers
{
    [Authorize]
    public class ProductosController : ApiController
    {
        private TiendaCarvajalAPIEntities db = new TiendaCarvajalAPIEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: api/Productos
        public IHttpActionResult GetProductos()
        {
            try
            {
                log.Debug("GetProductos, api/Productos/");
                ProductosNegocio productos = new ProductosNegocio();
                return Ok(productos.Productos());
            }
            catch(Exception ex)
            {
                log.Error("Excepcion:" + ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        // GET: api/Productos/5
        [ResponseType(typeof(Productos))]
        public IHttpActionResult GetProductos(int id)
        {
            try
            {
                log.Debug("GetProductos, api/Productos/" + id);
                Productos producto = db.Productos.Find(id);
                if (producto == null)
                {
                    log.Info("GetProductos, api/Productos/" + id + ": Regustro no existe");
                    return NotFound();
                }
                ProductosNegocio productos = new ProductosNegocio();
                return Ok(productos.ProductoPorId(id, producto));
            }
            catch(Exception ex)
            {
                log.Error("Excepcion:" + ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductos(int id, Productos productos)
        {
            try
            {
                log.Debug("PutProductos, api/Productos/" + id);
                if (!ModelState.IsValid)
                {
                    log.Error("PutProductos, api/Productos/" + id + ": Datos inconrrectos");
                    return BadRequest(ModelState);
                }

                if (id != productos.ProID)
                {
                    log.Error("PutProductos, api/Productos/" + id + ": Error interno");
                    return BadRequest();
                }

                db.Entry(productos).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosExists(id))
                    {
                        log.Error("PutProductos, api/Productos/" + id + ": No encontró el registro");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                log.Error("Excepcion:" + ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        // POST: api/Productos
        [ResponseType(typeof(Productos))]
        public IHttpActionResult PostProductos(ProductosEntidad productos)
        {
            try
            {
                log.Debug("PostProductos, api/Productos/");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ProductosNegocio Productos = new ProductosNegocio();
                Productos.GuardarProducto(productos);
                return CreatedAtRoute("DefaultApi", new { id = productos.ProID }, productos);
            }
            catch(Exception ex)
            {
                log.Error("Excepcion:" + ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(Productos))]
        public IHttpActionResult DeleteProductos(int id)
        {
            try
            {
                log.Debug("DeleteProductos, api/Productos/"+id);
                Productos productos = db.Productos.Find(id);
                if (productos == null)
                {
                    log.Error("DeleteProductos, api/Productos/" + id + ": Registro no existe");
                    return NotFound();
                }
                db.Productos.Remove(productos);
                db.SaveChanges();
                ProductosNegocio producto = new ProductosNegocio();
                return Ok(producto.ProductoPorIdDelete(id, productos));
            }
            catch(Exception ex)
            {
                log.Error("Excepcion:" + ex.Message);
                return new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError,
                    new HttpError($"{ex.StackTrace}//{ex.Message}"))
                );
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosExists(int id)
        {
            return db.Productos.Count(e => e.ProID == id) > 0;
        }
    }
}