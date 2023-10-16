using Plugin.Services.PluginServices;
using System.Reflection;

namespace Plugin.Services.Plugins
{
    public class PluginService : IPluginService
    {
        private readonly string PluginDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
        private readonly List<IPlugin> plugins = new List<IPlugin>();

        public bool InstallPlugin(string pluginName)
        {
            var plugin = plugins.Where(e=>e.Name.Trim().ToLower() == pluginName.ToLower()).FirstOrDefault(); 
            if (plugin != null)
            {
                plugin.InstallAsync();
               
                return true;
            }

            return false;
        }

        public PluginViewModel LoadPlugins()
        {
            var viewModel = new PluginViewModel();

            // Get all subdirectories within the plugin directory
            string[] pluginDirectories = Directory.GetDirectories(PluginDirectory);

            foreach (string pluginFolder in pluginDirectories)
            {
                foreach (string dllFile in Directory.GetFiles(pluginFolder, "*.dll"))
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);

                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type)!;
                            if (plugin.IsInstalled)
                            {
                                viewModel.InstalledPlugins.Add(plugin);
                            }
                            else
                            {
                                viewModel.UninstalledPlugins.Add(plugin);
                            }

                            plugins.Add(plugin);
                        }
                    }
                }
            }

            return viewModel;
        }

        public bool UnInstallPlugin(string pluginName)
        {
            var plugin = plugins.Where(e => e.Name.Trim().ToLower() == pluginName.ToLower()).FirstOrDefault();
            if (plugin != null)
            {
                plugin.UninstallAsync();

                return true;
            }

            return false;
        }
    }
}