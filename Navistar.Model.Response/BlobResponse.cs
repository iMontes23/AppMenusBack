using System.IO;

namespace Navistar.Model.Response
{
    public class BlobResponse : BaseResponse
    {
        public string ArchivoNombre { get; set; }

        public string ArchivoRuta { get; set; }

        public byte[] Content { get; set; }

        public BlobResponse(){}

        public BlobResponse(int codigo, string mensaje): base(codigo, mensaje)
        {
        }
    }
}
