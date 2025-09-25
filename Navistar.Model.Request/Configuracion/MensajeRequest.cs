using Navistar.Model.common.Enum;

namespace Navistar.Model.Request
{
    public class MensajeRequest
    {
        public MsgEnum Key { get; set; }
        public string Mensaje { get; set; }

        public MensajeRequest() { }

        public MensajeRequest(MsgEnum key, string mensaje)
        {
            Key = key;
            Mensaje = mensaje;
        }
    }
}
