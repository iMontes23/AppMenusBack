using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace Navistar.Utils.Logger
{
    public interface ILogger
    {
        ILog GetLog();
    }
}
