using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace Navistar.Utils.Logger
{
    public class Logger :ILogger
    {
          public static ILog Log => log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ILog GetLog()
        {
            return Log;
        }
    }
}
