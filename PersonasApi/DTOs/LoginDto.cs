using System.ComponentModel.DataAnnotations;

namespace PersonasApi.DTOs
{
    public class LoginDto
    {
        [Required] public string Usuario { get; set; } = null!;
        [Required] public string Pass { get; set; } = null!;
    }
}
