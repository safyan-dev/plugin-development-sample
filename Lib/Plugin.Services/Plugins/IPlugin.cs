namespace Plugin.Services.PluginServices
{
    public interface IPlugin
    {
        string Name { get; }
        string PluginLogo { get;}
        DateTime LastUpdated { get; }
        bool IsInstalled { get; }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task InstallAsync();

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task UninstallAsync();
    }
}
