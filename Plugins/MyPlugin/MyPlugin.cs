using Plugin.Services.PluginServices;
using System.Reflection;

namespace MyPlugin
{
    public class MyPlugin : IPlugin
    {
        public string Name => "My Plugin";
        public DateTime LastUpdated => DateTime.Now;
        public string PluginLogo {
            get
            {
                string logoPath = Name.Replace(" ", "").Trim() + "/logo.png";
                return logoPath;
            }
        }

        public bool IsInstalled { get; private set; } = true;

        public Task InstallAsync()
        {
            IsInstalled = true;
            return Task.CompletedTask;
        }

        public Task UninstallAsync()
        {
            IsInstalled = false;
            return Task.CompletedTask;
        }
    }
}