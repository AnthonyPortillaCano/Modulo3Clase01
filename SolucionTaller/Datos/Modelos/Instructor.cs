using System;
using System.Collections.Generic;

namespace Datos.Modelos
{
    public partial class Instructor
    {
        public Instructor()
        {
            Tallers = new HashSet<Taller>();
        }

        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Celular { get; set; }

        public virtual ICollection<Taller> Tallers { get; set; }
    }
}
