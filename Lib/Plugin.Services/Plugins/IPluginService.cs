using Plugin.Services.PluginServices;

namespace Plugin.Services.Plugins
{
    public interface IPluginService
    {
        public PluginViewModel LoadPlugins();
        public bool InstallPlugin(string pluginName); 
        public bool UnInstallPlugin(string pluginName);
    }
}
