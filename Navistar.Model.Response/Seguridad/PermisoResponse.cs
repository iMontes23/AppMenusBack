using System;

namespace Navistar.Model.Response.Seguridad
{
    public class PermisoResponse
    {
        public Boolean Consulta { get; set; }

        public Boolean Edicion { get; set; }

        public Boolean Admin { get; set; }

        public Boolean Autorizacion { get; set; }

        public Boolean Solicitar { get; set; }

        public PermisoResponse() { }

        public PermisoResponse(bool consulta, bool edicion, bool admin, bool autorizacion, bool solicitar)
        {
            this.Consulta = consulta;
            this.Edicion = edicion;
            this.Admin = admin;
            this.Autorizacion = autorizacion;
            this.Solicitar = solicitar;
        }

    }
}
