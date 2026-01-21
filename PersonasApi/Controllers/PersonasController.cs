using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasApi.DTOs;
using PersonasApi.Models;
using PersonasApi.Services;

namespace PersonasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        
        private readonly PersonasService _service;
        public PersonasController(PersonasService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> createPersona(PersonaDto dto)
        {
            var personas = await _service.CreatePersona(dto);
            return Ok(personas);
        }

        [HttpGet] // GET /api/personas
        public async Task<IActionResult> GetPersonas()
        {
            var personas = await _service.GetPersona();
            return Ok(personas);
        }

        [HttpGet("sp")] // GET /api/personas/sp
        public async Task<IActionResult> GetPersonasUsingSP()
        {
            var personas = await _service.GetPersonasUsingSP(); //Calling Store Procedure
            return Ok(personas);
        }
    }
}
