using System;

namespace Navistar.Model.Request
{
    public class BaseRequest
    {
        public Int64 Id { get; set; }

        public BaseRequest() { }

        public BaseRequest(Int64 id) {
            this.Id = id;
        }
    }
}
