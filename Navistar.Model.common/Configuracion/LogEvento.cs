using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Navistar.Model.common.Configuracion
{
    /// <summary>
    /// Clase de tipo entidad que representa la solicitud traslado por unidad (proceso existente)
    /// </summary>
    /// <remarks> Datos de la solicitud traslado por cada unidad </remarks>
    [Table("TETRA_LogEvento")]
    public class LogEvento
    {
        [Column("nu_ievento", TypeName = "bigint")]
        public long nu_ievento { get; set; }
        [Key]
        [Column("id_logevento", TypeName = "bigint")]
        public long id_logevento { get; set; }

        [Column("nb_tipo", TypeName = "nvarchar")]
        public string nb_tipo { get; set; }
        [Column("nb_tabla", TypeName = "nvarchar")]
        public string nb_tabla { get; set; }
        [Column("nb_uevento", TypeName = "nvarchar")]
        public string nb_uevento { get; set; }
        [Column("tx_regoriginal", TypeName = "nvarchar")]
        public string tx_regoriginal { get; set; }
        [Column("tx_regmodificado", TypeName = "nvarchar")]
        public string tx_regmodificado { get; set; }

        [Column("ts_fevento", TypeName = "smalldatetime")]
        public DateTime ts_fevento { get; set; }
    }
}
