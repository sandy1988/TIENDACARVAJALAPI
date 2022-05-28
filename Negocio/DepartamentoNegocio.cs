using SandyStoreWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandyStoreWS.Negocio
{
    public class DepartamentoNegocio
    {
        private TiendaCarvajalAPIEntities db = new TiendaCarvajalAPIEntities();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        internal object Departamentos()
        {
            try
            {
                var departamentos = from b in db.Departamentos
                                    select new DepartamentosEntidad()
                                    {
                                        DepID = b.DepID,
                                        DepDescripcion = b.DepDescripcion
                                    };
                return departamentos;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return null;
            }
        }
    }
}