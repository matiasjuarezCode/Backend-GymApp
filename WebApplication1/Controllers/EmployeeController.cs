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
        private readonly string url = "http://gymapp.somee.com/api/Employee";
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(url);
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
                employeeNew.BaseAddress = new Uri(url);
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
                employeePut.BaseAddress = new Uri(url);
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

                emplo.BaseAddress = new Uri(url);
                var response = emplo.GetAsync("Employee/" + employee.Id.ToString());
                response.Wait();

                var employeeGet = response.Result.Content.ReadAsAsync<Employee>();

                employee.Password = employeeGet.Result.Password;

            }

            using (var emploPut = new HttpClient())
            {
                emploPut.BaseAddress = new Uri(url + employee.Id.ToString());

                var putTask = emploPut.PutAsJsonAsync<Employee>("Employee/" + employee.Id, employee);
                putTask.Wait();

                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["success"] = $"Empleado {employee.LastName +" "+ employee.FirstName } Modificado";
                    return RedirectToAction("Index");
                }

                return View(employee);
            }
            
        }

        public IActionResult Delete(int id)
        {
            using (var emplo = new HttpClient())
            {

                emplo.BaseAddress = new Uri(url);
                var response = emplo.GetAsync("Employee/" + id.ToString());
                response.Wait();

                var employeeGet = response.Result.Content.ReadAsAsync<Employee>();

                return View(employeeGet.Result);

            }

        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            using (var employeePut = new HttpClient())
            {

                employeePut.BaseAddress = new Uri(url);
                var response = employeePut.DeleteAsync("Employee/" + employee.Id.ToString());
                response.Wait();

                var result = response.Result;
                TempData["success"] = $"Empleado ELIMINADO";
                return RedirectToAction("Index");

            }

            
        }

    }
}