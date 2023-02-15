using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.Interfaces;

namespace PhoneApp.Plugin
{
  class Loader
  {
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    public static List<IPluggable> Plugins = new List<IPluggable>();
    public static void LoadPlugins()
    {
      logger.Info("Loading plugins");
      var plugins = Directory.EnumerateFiles(".").Where(p => p.EndsWith(".Plugin.dll"));
      logger.Info($"Found {plugins.Count()} plugin(s)");

      foreach (var pluginPath in plugins)
      {
        logger.Info($"Loading {pluginPath}");
        Assembly assembly = Assembly.LoadFrom(pluginPath);
        foreach(var type in assembly.GetTypes())
        {
          if (type.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IPluggable))))
          {
            var authors = type.GetCustomAttributes(typeof(Author), false);

            if (authors.Length == 0)
            {
              throw new Exception("No authors provided. Untrusted plugin!");
            }

            foreach (var author in authors)
            {
              logger.Info($"Author {author.ToString()}");
            }

            var constructors = type.GetConstructors();
            var pluginInstance = constructors.First().Invoke(new object[] { });

            logger.Info("Plugin loaded and ready");

            Loader.Plugins.Add((pluginInstance as IPluggable));
          }
        }
      }
    }
  }
}
