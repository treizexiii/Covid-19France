using Covid_19France.Context;
using Covid_19France.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19France.Controllers
{
    public class HomeController : Controller
    {
        private const string GLOBAL_DATA_URL = "https://coronavirusapi-france.now.sh/FranceLiveGlobalData";
        private const string GLOBAL_DATA_TOKEN = "FranceGlobalLiveData";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var connection = new ApiConnection();
            await connection.RunAsync(GLOBAL_DATA_URL, GLOBAL_DATA_TOKEN);
            ViewData["decesTotals"] = connection.Datas.First().Deces + connection.Datas.First().DecesEhpad;
            return View(connection.Datas.First());
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
