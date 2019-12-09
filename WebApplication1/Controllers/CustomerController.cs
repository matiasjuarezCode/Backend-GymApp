using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectGym.Domain.Entities;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string url = "http://gymapp.somee.com/api/Customers";
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var listCustomer = JsonConvert.DeserializeObject<List<Customer>>(json);

            return View(listCustomer);
        }

        public IActionResult New()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(Customer model)
        {
            using (var customerNew = new HttpClient())
            {
                customerNew.BaseAddress = new Uri(url);
                var postJob = customerNew.PostAsJsonAsync<Customer>("Customers", model);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    TempData["success"] = "Cliente Agregado";
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(model);

        }
    }
}