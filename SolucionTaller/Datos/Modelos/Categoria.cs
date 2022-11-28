using System;
using System.Collections.Generic;

namespace Datos.Modelos
{
    public partial class Categoria
    {
        public Categoria()
        {
            Tallers = new HashSet<Taller>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Taller> Tallers { get; set; }
    }
}
