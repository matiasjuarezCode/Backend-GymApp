using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectGym.Domain.Entities;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://gymapp.somee.com/api/Employee");
            var listEmployees = JsonConvert.DeserializeObject<List<Employee>>(json);

            return View(listEmployees);
        }

        public IActionResult New()
        {
            var model = new Employee();
            return View(model);
        }

        [HttpPost]
        public IActionResult New(Employee model)
        {
            using (var employeeNew = new HttpClient())
            {
                employeeNew.BaseAddress = new Uri("http://gymapp.somee.com/api/Employee");
                var postJob = employeeNew.PostAsJsonAsync<Employee>("Employee", model);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                {
                    TempData["success"] = "Empleado Agregado";
                    return RedirectToAction("Index");
                }
                    
            }
            ModelState.AddModelError(string.Empty, "Error");
            return View(model);

        }

        public IActionResult Edit(int id)
        {
            Employee employee = null;

            using (var employeePut = new HttpClient())
            {
                employeePut.BaseAddress = new Uri("http://gymapp.somee.com/api/Employee");
                var response = employeePut.GetAsync("Employee/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<Employee>();
                    readtask.Wait();
                    employee = readtask.Result;
                }
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            using (var emplo = new HttpClient())
            {
                emplo.BaseAddress = new Uri("http://gymapp.somee.com/api/Employee");
                var putTask = emplo.PutAsJsonAsync<Employee>("Employee", employee);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View(employee);
            }
        }

        public IActionResult Delete(int id)
        {
            using (var employeePut = new HttpClient())
            {
                employeePut.BaseAddress = new Uri("http://gymapp.somee.com/api/Employee");
                var response = employeePut.GetAsync("Employee/" + id.ToString());
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    
    }
}