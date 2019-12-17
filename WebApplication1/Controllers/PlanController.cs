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
    public class PlanController : Controller
    {
        private readonly string url = "http://gymapp.somee.com/api/Plans";
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
            var listCustomer = JsonConvert.DeserializeObject<List<Plan>>(json);

            return View(listCustomer);
        }

        public IActionResult New()
        {
            var model = new Plan();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(Plan model)
        {
            using (var customerNew = new HttpClient())
            {
                customerNew.BaseAddress = new Uri(url);
                var postJob = customerNew.PostAsJsonAsync<Plan>("Plans", model);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    TempData["success"] = "Plan Agregado";
                    return RedirectToAction("Index");
                }

            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(model);

        }

        public IActionResult Edit(int id)
        {
            Plan customer = null;

            using (var customerPut = new HttpClient())
            {
                customerPut.BaseAddress = new Uri(url);
                var response = customerPut.GetAsync("Plans/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Plan>();
                    readtask.Wait();
                    customer = readtask.Result;
                }
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Plan customer)
        {
            using (var emploPut = new HttpClient())
            {
                emploPut.BaseAddress = new Uri(url + customer.Id.ToString());

                var putTask = emploPut.PutAsJsonAsync<Plan>("Plans/" + customer.Id, customer);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["success"] = $"Plan {customer.Description } Modificado";
                    return RedirectToAction("Index");
                }

                return View(customer);
            }

        }

        public IActionResult Delete(int id)
        {
            using (var emplo = new HttpClient())
            {

                emplo.BaseAddress = new Uri(url);
                var response = emplo.GetAsync("Plans/" + id.ToString());
                response.Wait();

                var employeeGet = response.Result.Content.ReadAsAsync<Plan>();

                return View(employeeGet.Result);

            }

        }

        [HttpPost]
        public IActionResult Delete(Plan employee)
        {
            using (var employeePut = new HttpClient())
            {

                employeePut.BaseAddress = new Uri(url);
                var response = employeePut.DeleteAsync("Plans/" + employee.Id.ToString());
                response.Wait();

                var result = response.Result;
                TempData["success"] = $"Plan ELIMINADO";
                return RedirectToAction("Index");

            }


        }
    }
}