//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_de_inventario_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Transacciones
    {
        public string Id_Transaccion { get; set; }
        public string Tipo_Transaccion { get; set; }
        public string Id_Articulo { get; set; }
        public System.DateTime Fecha { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Cantidad { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El Monto debe ser mayor que cero")]
        public decimal Monto { get; set; }
    
        public virtual Articulo Articulo { get; set; }
    }
}