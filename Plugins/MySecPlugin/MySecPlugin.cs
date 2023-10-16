using Plugin.Services.PluginServices;

namespace MySecPlugin
{
    internal class MySecPlugin : IPlugin
    {
        public string Name => "My Sec Plugin";

        public DateTime LastUpdated => DateTime.Now;
        public string PluginLogo
        {
            get
            {
                string logoPath = Name.Replace(" ", "").Trim() + "/logo.png";
                return logoPath;
            }
        }

        public bool IsInstalled { get; private set; } = false;

        public Task InstallAsync()
        {
            IsInstalled = true; // set this property in plugin table in db for real time change effect
            return Task.CompletedTask;
        }

        public Task UninstallAsync()
        {
            IsInstalled = false; // set this property in plugin table in db for real time change effect
            return Task.CompletedTask;
        }
    }
}
