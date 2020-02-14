using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Final_Project_MVC.Models;
using RestSharp;
using System.Threading;
using Newtonsoft.Json;

namespace Final_Project_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       


        public async Task<IActionResult> Index()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "https://localhost:44319/api/menu";
            var restResponse = await client.ExecuteAsync(request, CancellationToken.None);
            string content = restResponse.Content;
            var menu = JsonConvert.DeserializeObject<IEnumerable<Menu>>(content);

            return View(menu);
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
