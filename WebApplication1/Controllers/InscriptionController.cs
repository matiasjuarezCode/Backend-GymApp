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
    public class InscriptionController : Controller
    {
        private readonly string url = "http://gymapp.somee.com/api/Inscription";
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var listInscritions = JsonConvert.DeserializeObject<List<Inscription>>(json);

            return View(listInscritions);
        }

        public IActionResult New()
        {
            var model = new Inscription();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(Inscription model)
        {
            using (var inscriptionNew = new HttpClient())
            {
                inscriptionNew.BaseAddress = new Uri(url);
                var postJob = inscriptionNew.PostAsJsonAsync<Inscription>("Inscription", model);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    TempData["success"] = "Cliente Inscripto";
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(model);

        }
    }
}