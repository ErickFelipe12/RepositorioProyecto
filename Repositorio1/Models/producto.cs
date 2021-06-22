//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositorio1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.producto_compra = new HashSet<producto_compra>();
            this.producto_imagen = new HashSet<producto_imagen>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "El nombre no puede ir vacio")]
        [StringLength(20, ErrorMessage = "Supero el limite de 20 caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El precio unitario no puede ir vacio")]
        public int percio_unitario { get; set; }
        [Required(ErrorMessage = "Cada producto debe tener una descripción")]
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public int id_proveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_compra> producto_compra { get; set; }
        public virtual proveedor proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_imagen> producto_imagen { get; set; }
    }
}
