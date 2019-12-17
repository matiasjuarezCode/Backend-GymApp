using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGym.Domain.Entities;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private readonly IInscriptionRepository _inscriptionRepository;

        public InscriptionController(IInscriptionRepository inscriptionRepository)
        {
            _inscriptionRepository = inscriptionRepository;
        }

        // GET: api/Inscription
        [HttpGet]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Get()
        {
            var inscripciones = await _inscriptionRepository.GetAll();
            return Ok(inscripciones.Where(x => !x.IsDelete));
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(long id)
        {
            var inscription = await _inscriptionRepository.GetById(id);

            if (inscription == null)
            {
                return Ok("No Existe");
            }

            return Ok(inscription);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Put(Inscription inscription, long id)
        {
            var _inscription = await _inscriptionRepository.GetById(id);

            if (_inscription == null)
            {
                return Ok("No Existe");
            }
            else
            {
                _inscription.Id = id;
                _inscription.CustomerId = inscription.CustomerId;
                _inscription.InscriptionDate = inscription.InscriptionDate;
                _inscription.PlanId = inscription.PlanId;
                _inscription.ExpirationDate = inscription.ExpirationDate;
               
                await _inscriptionRepository.Update(_inscription);
                return Ok(_inscription);
            }
        }

        // POST: api/Customers
        [HttpPost]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Post(Inscription inscription)
        {               
                await _inscriptionRepository.Insert(inscription);
                return Ok(inscription);          
        }
        
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(long id)
        {
            var InscriptionDelete = await _inscriptionRepository.GetById(id);
            if (InscriptionDelete != null)
            {
                await _inscriptionRepository.Delete(InscriptionDelete);
                return Ok(InscriptionDelete);
            }
            else
            {
                return Ok("No Existe");
            }
        }


    }
}