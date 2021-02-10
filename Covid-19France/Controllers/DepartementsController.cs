using Covid_19France.Context;
using Covid_19France.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19France.Controllers
{
    public class DepartementsController : Controller
    {
        private const string ALL_DEPT_URL = "https://coronavirusapi-france.now.sh/AllLiveData";
        private const string ALL_DEP_TOKEN = "allLiveFranceData";

        private static HttpClient client = new HttpClient();

        public async Task<IActionResult> IndexAsync()
        {
            var connection = new ApiConnection();
            await connection.RunAsync(ALL_DEPT_URL, ALL_DEP_TOKEN);
            return View(connection.Datas);
        }
    }
}
