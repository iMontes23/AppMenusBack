using Microsoft.VisualStudio.TestTools.UnitTesting;
using Navistar.Model.common.Enum;
using Navistar.Model.Request;
using System.Collections.Generic;

namespace Navistar.Test.Business.CoreImp
{
    [TestClass]
    public class MensajeBusinessImpTest
    {
        [TestMethod]
        public void GuardarMensajes() {}

        private void CrearMensajesIniciales ()
        {
            IList<MensajeRequest> mensajes = new List<MensajeRequest>();
            /*0*/   mensajes.Add(new MensajeRequest(MsgEnum.GENERAL_EXI_001, "Operación exitosa"));
            /*1*/   mensajes.Add(new MensajeRequest(MsgEnum.GENERAL_ERR_001, "Dato(s) inválido(s)"));
            /*2*/   mensajes.Add(new MensajeRequest(MsgEnum.GENERAL_ERR_002, "Dato(s) requerido(s)"));
            /*3*/   mensajes.Add(new MensajeRequest(MsgEnum.GENERAL_ERR_003, "Valor duplicado"));
            /*4*/   mensajes.Add(new MensajeRequest(MsgEnum.GENERAL_ERR_004, "Ha ocurrido un error en el servidor"));

            /*11*/  mensajes.Add(new MensajeRequest(MsgEnum.RUTA_MONTAJE_EXI_001, "Ruta por montaje guardada"));
            /*12*/  mensajes.Add(new MensajeRequest(MsgEnum.RUTA_MONTAJE_EXI_002, "Ruta por montaje actualizada"));
            /*13*/  mensajes.Add(new MensajeRequest(MsgEnum.RUTA_MONTAJE_ERR_001, "Duplicado"));
        }
     }
}
