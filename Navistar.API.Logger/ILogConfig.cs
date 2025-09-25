using System;
using System.Collections.Generic;
using System.Text;

namespace Navistar.API.Logger
{
    public interface ILogConfig
    {
        void setConfig();
        NLog.Config.LoggingConfiguration getConfig();
    }
}
