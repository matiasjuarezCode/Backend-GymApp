using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGym.Domain.Entities;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Implementation;
using ProjectGym.Service.Inferface;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISegurityRepository _segurityRepository;

     

        public EmployeeController(IEmployeeRepository employeeRepository, ISegurityRepository segurityRepository)
        {
            _employeeRepository = employeeRepository;
            _segurityRepository = segurityRepository;
        }
        

        [HttpGet]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Get()
        {
                var employee = await _employeeRepository.GetAll();
                return Ok(employee.Where(x=>!x.IsDelete));
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var employe = await _employeeRepository.GetById(id);
            if (employe != null)
            {
                return Ok(employe);
            }
            else
            {
                return Ok("Employee NotExist");
            }
           
        }

        // POST: api/Employee
        [HttpPost]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Insert(Employee employee)
        {
            if (await _segurityRepository.VerifyExists(employee.Username))
            {
                return Ok("Usuario Ya Existente");
            }
            else
            {
                if(await VerifyExistLegacy(employee.Legacy))
                {
                    return Ok("Ya Existe Empleado con mismo Legajo");
                }
                else
                {
                    var newEmployee = new Employee()
                    {
                        Legacy = employee.Legacy,
                        LastName = employee.LastName,
                        FirstName = employee.FirstName,
                        Adress = employee.Adress,
                        Phone = employee.Phone,
                        Username = employee.Username,
                        Password = employee.Password,

                    };

                    await _employeeRepository.Insert(newEmployee);
                    return Ok(employee);
                }             
            }         
        }

        private async Task<bool> VerifyExistLegacy(int legacy)
        {
            var employees = await  _employeeRepository.GetAll();
            return employees.Any(x => x.Legacy == legacy);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Put(Employee employee, int id)
        {
            var _employee = await _employeeRepository.GetById(id);

            if (_employee != null)
            {
                                 
                     _employee.Legacy = employee.Legacy;
                     _employee.LastName = employee.LastName;
                     _employee.FirstName = employee.FirstName;
                     _employee.Adress = employee.Adress;
                     _employee.Phone = employee.Phone;
                     _employee.Username = employee.Username;
                     _employee.Password = employee.Password;
                            
                      await _employeeRepository.Update(_employee);
                      return Ok(_employee);           
            }
            else
            {
                return Ok("Employee NotExist");
            }

            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            var employedelete = await _employeeRepository.GetById(id);
            if (employedelete != null)
            {
                await _employeeRepository.Delete(employedelete);
                return Ok(employedelete);

            }
            else
            {
                return Ok("Employee NotExist");
            }

          

        }
    }
}
