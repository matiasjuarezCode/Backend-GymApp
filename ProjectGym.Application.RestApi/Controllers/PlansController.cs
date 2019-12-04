using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Domain.Entities;
using ProjectGym.Infraestructure;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IPlanRepository _planRepository;

        public PlansController(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        // GET: api/Plans
        [HttpGet]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Get()
        {
            var plans = await _planRepository.GetAll();
            return Ok(plans.Where(x => !x.IsDelete));
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(long id)
        {
            var plan = await _planRepository.GetById(id);

            if (plan == null)
            {
                return Ok("NoExiste");
            }

            return Ok(plan);
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Put(Plan plan, long id)
        {
            var _plan = await _planRepository.GetById(id);

            if(_plan == null)
            {
                return Ok("ERRO NO EXISTE");
            }
            else
            {
                _plan.Id = id;
                _plan.Description = plan.Description;
                _plan.Price = plan.Price;

                await _planRepository.Update(_plan);
                return Ok(_plan);
            }
            
        }

        // POST: api/Plans
        [HttpPost]
        public async Task<IActionResult> Post(Plan plan)
        {
            await _planRepository.Insert(plan);
            return Ok(plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {

            var plandelete = await _planRepository.GetById(id);

            if(plandelete != null)
            {
                await _planRepository.Delete(plandelete);
                return Ok(plandelete);
            }
            else
            {
                return Ok("No Existe");
            }
        }

       
    }
}
