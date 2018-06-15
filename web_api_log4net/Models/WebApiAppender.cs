using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace web_api_log4net.Models
{
    public class WebApiAppender : AppenderSkeleton
    {
        string loglevel;

        protected override void Append(LoggingEvent loggingEvent)
        {
            // Getting the level of the logging
            loglevel = loggingEvent.Level.Name;

            var properties = loggingEvent.Properties;
            properties["Username"] = "TestUser2";
            properties["UserId"] = 200;

            string jsonString = RenderLoggingEvent(loggingEvent);

            WebApiLogger apiLogger = new WebApiLogger("http", "Insæt ip/adresse", 12345, loglevel, "api/Log", jsonString);

        }
    }
}