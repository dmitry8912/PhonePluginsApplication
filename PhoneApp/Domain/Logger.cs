using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.Domain
{
  public class Logger
  {
    public static void Configure()
    {
      var configuration = new NLog.Config.LoggingConfiguration();
      var consoleTarget = new NLog.Targets.ColoredConsoleTarget("console");
      consoleTarget.Layout = "${longdate} | ${uppercase:${level}} | ${message}";
      consoleTarget.RowHighlightingRules.Add(
          new NLog.Targets.ConsoleRowHighlightingRule(
            "level >= LogLevel.Error",
            NLog.Targets.ConsoleOutputColor.White,
            NLog.Targets.ConsoleOutputColor.Red
          )
      );
      consoleTarget.RowHighlightingRules.Add(
        new NLog.Targets.ConsoleRowHighlightingRule(
          "level == LogLevel.Debug",
          NLog.Targets.ConsoleOutputColor.DarkYellow,
          NLog.Targets.ConsoleOutputColor.Black
        )
      );
      consoleTarget.RowHighlightingRules.Add(
        new NLog.Targets.ConsoleRowHighlightingRule(
          "level == LogLevel.Info",
          NLog.Targets.ConsoleOutputColor.Green,
          NLog.Targets.ConsoleOutputColor.Black
        )
      );

      configuration.AddRule(NLog.LogLevel.Trace, NLog.LogLevel.Fatal, consoleTarget);
      
      NLog.LogManager.Configuration = configuration;
    }
  }
}
