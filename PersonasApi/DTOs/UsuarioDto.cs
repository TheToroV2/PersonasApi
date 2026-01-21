using System.ComponentModel.DataAnnotations;

namespace PersonasApi.DTOs
{
    public class UsuarioDto
    {
        [Required] public string Usuario { get; set; } = null!;
        [Required] public string Pass { get; set; } = null!;
    }
}
