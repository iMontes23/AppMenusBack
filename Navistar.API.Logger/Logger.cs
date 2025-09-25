using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Targets;
using NLog.Config;

namespace Navistar.API.Logger
{
    public class Logger : ILogConfig
    {
        private LoggingConfiguration _config;
        public   NLog.Logger logger;

        public Logger()
        {
            this.setConfig();
            LogManager.Configuration = getConfig();
            logger = LogManager.GetLogger("Log API");
        }

        public LoggingConfiguration getConfig()
        {
            return _config;
        }

        public void setConfig()
        {
            // Step 1. Create configuration object 
            this._config = new LoggingConfiguration();

            // Step 2. Create targets
            var consoleTarget = new ColoredConsoleTarget("target1")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
            };
            _config.AddTarget(consoleTarget);

            var fileTarget = new FileTarget("target2")
            {
                FileName = "${basedir}/file.txt",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };
            _config.AddTarget(fileTarget);


            // Step 3. Define rules
            _config.AddRuleForOneLevel(LogLevel.Error, fileTarget); // only errors to file
            _config.AddRuleForAllLevels(consoleTarget);
     
        }

    }
}
