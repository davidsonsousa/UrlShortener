using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.Web.Controllers.Lib;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new ShortenViewModel());
        }

        [HttpPost]
        public IActionResult Index(ShortenViewModel shortenViewModel)
        {
            // In the real world I'd call a service that would:
            // 1. Clean the URL to remove unnecessary parameters
            // 2. Shorten the URL (Shorten.GenerateCode)
            // 3. Check if code already exists in the DB
            // 4. Insert new code + original URL in the DB

            shortenViewModel.ShortenUrl = $"https://cor.to/{Shorten.GenerateCode(8)}";

            return View(shortenViewModel);
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

    }
}
