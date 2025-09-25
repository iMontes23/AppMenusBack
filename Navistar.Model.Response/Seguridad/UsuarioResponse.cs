using Navistar.Model.common;
using System;
using System.Collections.Generic;

namespace Navistar.Model.Response.Seguridad
{
    public class UsuarioResponse : BaseResponse
    {
        public String NombreUsuario { get; set; }

        public String Correo { get; set; }

        public HashSet<String> Menus { get; set; }

        public Dictionary<String, bool> Permissions { get; set; }

        public Int64? CodigoTrasladista { get; set; }

        public String Perfil { get; set; }

        public UsuarioResponse(String nombreUsuario, String correo, HashSet<String> menus, Int64? codigoTrasladista, String userRol) : base(Constante.COD_200, String.Empty)
        {
            NombreUsuario = nombreUsuario;
            Correo = correo;
            Menus = menus;
            CodigoTrasladista = codigoTrasladista;
            Perfil = userRol;
        }


        public UsuarioResponse(String nombreUsuario, String correo, Int64? codigoTrasladista, String userRol) : base(Constante.COD_200, String.Empty)
        {
            NombreUsuario = nombreUsuario;
            Correo = correo;
            CodigoTrasladista = codigoTrasladista;
            Perfil = userRol;
        }

        public UsuarioResponse(String nombreUsuario, String correo) : base(Constante.COD_200, String.Empty)
        {
            NombreUsuario = nombreUsuario;
            Correo = correo;
        }
        public UsuarioResponse() : base(Constante.COD_200, String.Empty)
        {
        }
    }
}
