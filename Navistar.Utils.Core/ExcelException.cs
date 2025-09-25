using Navistar.Model.common.Enum;
using System;

namespace Navistar.Utils.Core
{
    public class ExcelException : BusinessException
    {
        public MsgEnum ValorEnum { get; }
        public string MensajeEnum { get; }

        public ExcelException(MsgEnum valorEnum, string mensajeEnum)
        {
            this.ValorEnum = valorEnum;
            this.MensajeEnum = mensajeEnum;
        }
        public ExcelException(MsgEnum valorEnum)
        {
            this.ValorEnum = valorEnum;
        }

        public ExcelException(String mensaje)
        {
            this.MensajeEnum = mensaje;
        }
    }
}
