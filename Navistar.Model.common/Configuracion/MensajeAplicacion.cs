using Navistar.Model.common.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Navistar.Model.common
{
    /// <summary>
    /// Clase que representa el manejo de los mensajes presentados en la aplicación
    /// </summary>
    [Table("TCTRA_MensajeApp")]
    public class MensajeAplicacion
    {
        /// <summary>
        /// Identificador de la clase
        /// </summary>
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Tipo de mensaje
        /// </summary>
        [Required]
        [Column("key", TypeName = "int")]
        public MsgEnum Key { get; set; }

        /// <summary>
        /// Mensaje a mostrar
        /// </summary>
        [Required]
        [Column("mensaje", TypeName = "nvarchar(100)")]
        public string Mensaje { get; set; }

        /// <summary>
        /// Constructor por default
        /// </summary>
        public MensajeAplicacion() { }

        public MensajeAplicacion(MsgEnum key, string mensaje)
        {
            this.Key = key;
            this.Mensaje = mensaje;
        }

        public MensajeAplicacion(int id, MsgEnum key, string mensaje)
        {
            this.Id = id;
            this.Key = key;
            this.Mensaje = mensaje;
        }
    }
}
