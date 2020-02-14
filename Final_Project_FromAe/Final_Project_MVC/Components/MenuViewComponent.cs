using Final_Project_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Project_MVC.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "https://localhost:44319/api/menu";
            var restResponse = await client.ExecuteAsync(request, CancellationToken.None);
            string content = restResponse.Content;
            var menu = JsonConvert.DeserializeObject<IEnumerable<Menu>>(content);

            return View(menu);
        }
    }
}
