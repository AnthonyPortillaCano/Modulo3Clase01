using System;
using System.Collections.Generic;

namespace Datos.Modelos
{
    public partial class Taller
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? CodigoInstructor { get; set; }
        public int? CodigoCategoria { get; set; }

        public virtual Categoria? CodigoCategoriaNavigation { get; set; }
        public virtual Instructor? CodigoInstructorNavigation { get; set; }
    }
}
