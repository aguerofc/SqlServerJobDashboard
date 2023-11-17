using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SqlAgentDashboard.Models;
using System.Diagnostics;

namespace ActiveDirectoryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetJobsInfo", "Job");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       /// <summary>
       /// Logout action
       /// </summary>
       /// <returns></returns>
        public  IActionResult Logout()
        {
            
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //// Redirect to a page or action after "logging out"
            return View();
        }

        public IActionResult Unauthorize()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //// Redirect to a page or action after "logging out"
            return View();
        }
    }
}