using System;
using System.Collections.Generic;

namespace Tiendaapi;

public partial class Personal
{
    public int IdPersonal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public string Oficina { get; set; } = null!;

    public string Responsabilidad { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Movil { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Nif { get; set; }

    public bool Baja { get; set; }

    public string? FechaBaja { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
