using Microsoft.AspNetCore.Mvc;
using Plugin.Services.Plugins;

namespace Plugin.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPluginService _pluginService;

        public HomeController(ILogger<HomeController> logger, IPluginService pluginService)
        {
            _logger = logger;
            _pluginService = pluginService;
        }

        public IActionResult Index()
        {
            var plugins = _pluginService.LoadPlugins();
            ViewBag.Plugins = plugins;
            return View();
        }

        public IActionResult Install(string pluginName)
        {
            _pluginService.InstallPlugin(pluginName);
            return RedirectToAction("Index");
        }
        public IActionResult UnInstall(string pluginName)
        {
            _pluginService.UnInstallPlugin(pluginName);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
