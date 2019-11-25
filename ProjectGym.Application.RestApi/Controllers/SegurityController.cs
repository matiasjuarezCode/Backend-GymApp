using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectGym.Service.Implementation;
using ProjectGym.Service.Inferface;
using ProjectGym.Service.Interface;

namespace ProjectGym.Application.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurityController : ControllerBase
    {
        private readonly ISegurityRepository _segurityRepository;
        public SegurityController(ISegurityRepository segurityRepository)
        {
            _segurityRepository = segurityRepository;

        }


        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            bool entry = await _segurityRepository.Login(username, password);

            return Ok(entry);

        }
    }
}