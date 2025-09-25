using Navistar.Model.common;
using System;

namespace Navistar.Model.Response
{
    public class BaseResponse
    {
        public Int64 Id { get; set; }

        public Int32 Codigo { get; set; }

        public String Mensaje { get; set; }
        
        public BaseResponse()
        {
            this.Codigo = Constante.COD_200;
            this.Mensaje = String.Empty;
        }
        public BaseResponse(Int32 id)
        {
            this.Id = id;
            this.Codigo = Constante.COD_200;
            this.Mensaje = String.Empty;
        }
        public BaseResponse(Int32 codigo, String mensaje)
        {
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }
        public BaseResponse(Int32 codigo, String mensaje, Int64 id)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }
    }
}
