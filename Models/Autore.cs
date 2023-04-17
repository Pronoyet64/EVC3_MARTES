using System;
using System.Collections.Generic;

namespace EVC3_MARTES.Models;

public partial class Autore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
