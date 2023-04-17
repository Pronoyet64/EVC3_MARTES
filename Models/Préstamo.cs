using System;
using System.Collections.Generic;

namespace EVC3_MARTES.Models;

public partial class Préstamo
{
    public int Id { get; set; }

    public int LibroId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime FechaPréstamo { get; set; }
}
