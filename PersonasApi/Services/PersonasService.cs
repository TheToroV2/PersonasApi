using Microsoft.EntityFrameworkCore;
using PersonasApi.DTOs;
using PersonasApi.Models;

namespace PersonasApi.Services
{
    public class PersonasService
    {
        private readonly AppDbContext _context;

        public PersonasService(AppDbContext context)
        {
            _context = context;
        }

        //Create a new persona
        public async Task<Persona> CreatePersona(PersonaDto dto)
        {
            var persona = new Persona
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                NumeroIdentificacion = dto.NumeroIdentificacion,
                TipoIdentificacion = dto.TipoIdentificacion,
                Email = dto.Email,
                FechaCreacion = DateTime.Now
            };

            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        //Get al personas
        public async Task<List<Persona>> GetPersona()
        {
            var personas = await _context.Personas.ToListAsync();
            return personas;
        }

        //Using the store Procedure
        public async Task<List<Persona>> GetPersonasUsingSP()
        {
            return await _context.Personas
                .FromSqlRaw("EXEC sp_ConsultarPersonas")
                .ToListAsync();
        }
    }
}
