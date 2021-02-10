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
        private const string DATA_BY_DEPT_URL = "https://coronavirusapi-france.now.sh/AllDataByDepartement";
        private const string ALL_DEP_TOKEN = "allLiveFranceData";
        private const string BY_DEP_TOKEN = "allDataByDepartement";

        public async Task<IActionResult> IndexAsync()
        {
            var connection = new ApiConnection();
            await connection.RunAsync(ALL_DEPT_URL, ALL_DEP_TOKEN);
            return View(connection.Datas);
        }

        public async Task<IActionResult> DetailsAsync(string id)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "Departement", id }
            };

            var connection = new ApiConnection();
            await connection.RunAsync(DATA_BY_DEPT_URL, BY_DEP_TOKEN, parameters);
            return View(connection.Datas.Reverse<Data>());
        }
    }
}
