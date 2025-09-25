using System;

namespace Navistar.Utils.Core
{
    public class BusinessException : Exception
    {
        public override string Message { get; }

        public BusinessException(){}
        public BusinessException(string message)
        {
            this.Message = message;
        }
    }
}
