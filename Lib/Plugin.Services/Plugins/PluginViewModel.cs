using Plugin.Services.PluginServices;

namespace Plugin.Services.Plugins
{
    public class PluginViewModel
    {
        public PluginViewModel()
        {
            InstalledPlugins = new List<IPlugin>();
            UninstalledPlugins = new List<IPlugin>();
        }
        public List<IPlugin> InstalledPlugins { get; set; }
        public List<IPlugin> UninstalledPlugins { get; set; }
    }
}