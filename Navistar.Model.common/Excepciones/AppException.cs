using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.Model.common.Excepciones
{
    public class AppException : Exception
    {
        public int ErrorCode { get; }

        public AppException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public override string ToString()
        {
            return $"Código de error: {ErrorCode} - {Message}";
        }
    }
}
