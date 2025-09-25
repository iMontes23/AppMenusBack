using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Navistar.Model.common
{
    /// <summary>
    /// Super clase de la cual se heredan los atributos básicos de la aplicación
    /// </summary>
    [NotMapped]
    public class Base
    {
        /// <summary>
        /// Identificador de la clase
        /// </summary>
        [Key]
        [Column("id", TypeName = "bigint")]
        public Int64 Id { get; set; }

        /// <summary>
        /// Fecha de alta
        /// </summary>
        [Column("fh_Creacion", TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Creacion { get; set; }

        /// <summary>
        /// Fecha de la última modificación al objeto
        /// </summary>
        [Column("fh_Actualizacion", TypeName = "datetime")]
        public DateTime Actualizacion { get; set; }
    }
}
