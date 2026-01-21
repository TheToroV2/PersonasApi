using System.ComponentModel.DataAnnotations;

namespace PersonasApi.DTOs
{
    public class PersonaDto
    {
        [Required] public string Nombres { get; set; } = null!;
        [Required] public string Apellidos { get; set; } = null!;
        [Required] public string NumeroIdentificacion { get; set; } = null!;
        [Required] public string TipoIdentificacion { get; set; } = null!;
        [Required, EmailAddress] public string Email { get; set; } = null!;
    }
}
