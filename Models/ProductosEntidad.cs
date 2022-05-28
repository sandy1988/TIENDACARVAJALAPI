using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandyStoreWS.Models
{
    public class ProductosEntidad
    {
        public int ProID { get; set; }
        public int DepID { get; set; }
        public string DepDescripcion { get; set; }
        public string ProNombre { get; set; }
        public string ProDescripcion { get; set; }
        public double? ProValor { get; set; }
        public string ProRutaImagen { get; set; }
    }
}