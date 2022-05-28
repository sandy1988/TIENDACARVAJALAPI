using SandyStoreWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SandyStoreWS.Clases
{
    public class ProductosNegocio
    {
        private TiendaCarvajalAPIEntities db = new TiendaCarvajalAPIEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        internal object Productos()
        {
            try
            {
                var productos = from b in db.Productos
                                select new ProductosEntidad()
                                {
                                    ProID = b.ProID,
                                    DepID = b.Departamentos.DepID,
                                    DepDescripcion = b.Departamentos.DepDescripcion,
                                    ProNombre = b.ProNombre,
                                    ProDescripcion = b.ProDescripcion,
                                    ProValor = b.ProValor,
                                    ProRutaImagen = b.ProRutaImagen
                                };
                return productos;
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        internal object ProductoPorId(int id, Productos productos)
        {
            try
            {
                ProductosEntidad Producto = new ProductosEntidad()
                {
                    ProID = productos.ProID,
                    DepID = productos.Departamentos.DepID,
                    DepDescripcion = productos.Departamentos.DepDescripcion,
                    ProNombre = productos.ProNombre,
                    ProDescripcion = productos.ProDescripcion,
                    ProValor = productos.ProValor,
                    ProRutaImagen = productos.ProRutaImagen
                };
                return Producto;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        internal object ProductoPorIdDelete(int id, Productos productos)
        {
            try
            {
                ProductosEntidad Producto = new ProductosEntidad()
                {
                    ProID = productos.ProID,
                    ProNombre = productos.ProNombre,
                    ProDescripcion = productos.ProDescripcion,
                    ProValor = productos.ProValor,
                    ProRutaImagen = productos.ProRutaImagen
                };
                return Producto;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }

        internal void GuardarProducto(ProductosEntidad producto)
        {
            try
            {
                Productos listProductos = new Productos();
                listProductos.DepID = producto.DepID;
                listProductos.ProNombre = producto.ProNombre;
                listProductos.ProDescripcion = producto.ProDescripcion;
                listProductos.ProValor = producto.ProValor;
                listProductos.ProRutaImagen = producto.ProRutaImagen;

                db.Productos.Add(listProductos);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}