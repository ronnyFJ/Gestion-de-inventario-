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
    
    public partial class Almacenes
    {

        public string Id_Almacen { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    
        public virtual Existencias_Por_Almacen Existencias_Por_Almacen { get; set; }
    }
}
