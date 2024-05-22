using System;
using System.Collections.Generic;

namespace Tiendaapi;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string Email { get; set; } = null!;

    public DateTime FechaAlta { get; set; }

    public string ModoAutenticacion { get; set; } = null!;

    public bool Activo { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
