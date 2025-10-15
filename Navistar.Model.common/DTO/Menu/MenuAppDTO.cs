using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.common.DTO.Menu
{
    public class MenuAppDTO
    {
        public int AppId { get; set; }              // cb_appId
        public string NombreMenu { get; set; }      // tx_nombreMenu
        public string CodigoApp { get; set; }       // tx_codigoApp
        public string Descripcion { get; set; }     // tx_descripcion
        public bool Activo { get; set; }            // st_activo
        /*
        public DateTime Creacion { get; set; }      // fh_creacion
        public string UsuarioCreacion { get; set; } // tx_usuarioCreacion
        public DateTime? Modificacion { get; set; } // fh_modificacion
        public string UsuarioMoficacion { get; set; } // tx_usuarioMoficacion
        */
        public override string ToString()
        {
            return $"Id: {AppId}, " +
                   $"Nombre: {NombreMenu}, " +
                   $"Código: {CodigoApp}, " +
                   $"Descripción: {Descripcion}, " +
                   $"Activo: {Activo} ";
                  // $"Creado: {Creacion:yyyy-MM-dd HH:mm:ss} por {UsuarioCreacion}, " +
                   //$"Modificado: {(Modificacion.HasValue ? Modificacion.Value.ToString("yyyy-MM-dd HH:mm:ss") : "N/A")} por {UsuarioMoficacion}";
        }
    }
}