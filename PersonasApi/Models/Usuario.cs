using System;
using System.Collections.Generic;

namespace PersonasApi.Models;

public partial class Usuario
{
    public int Identificador { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }
}
