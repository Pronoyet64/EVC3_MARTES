using System;
using System.Collections.Generic;

namespace EVC3_MARTES.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Título { get; set; } = null!;

    public int AutorId { get; set; }

    public int GéneroId { get; set; }

    public int EstadoId { get; set; }

    public int AñoPublicación { get; set; }

    public virtual Autore Autor { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual Género Género { get; set; } = null!;
}
