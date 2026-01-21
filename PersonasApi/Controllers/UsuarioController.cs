using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasApi.DTOs;
using PersonasApi.Models;
using PersonasApi.Services;
using System.Security.Cryptography;

namespace PersonasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UsuarioDto dto)
        {
            var user = await _service.Register(dto);
            return Ok(new { message = "User registered", user = user.Usuario1 });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDto dto)
        {
            var result = await _service.Login(dto);

            if (!result.Success)
                return Unauthorized(new { message = result.Message });

            return Ok(new { message = result.Message, usuario = result.Usuario });
        }
    }
}