using Microsoft.AspNetCore.Mvc;
using MyPlugin.Models;

namespace MyPlugin.Controllers
{
    [Route("[controller]")]
    public class MyPluginController : Controller
    {
        [HttpGet]
        public IActionResult Configure()
        {
            return View("~/Plugins/MyPlugin/Views/Configure.cshtml", new ConfigureViewModel());
        }

        [HttpPost]
        public IActionResult Configure(ConfigureViewModel model)
        {
            var configureView = new ConfigureViewModel();
            if (model.CallToMyPlugin) 
            {
                configureView.Message = "Hello! Welcome from MyPlugin!";

                return Json(new { Message = configureView.Message });
            }

            return View("~/Plugins/MyPlugin/Views/Configure.cshtml", configureView);
        }
    }
}