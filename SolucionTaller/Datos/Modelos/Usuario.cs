using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Datos.Modelos
{
    public partial class Usuario
    {
        public int Id { get; set; }


        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Clave { get; set; }
        public string? TokenRecovery { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Bloqueado { get; set; }
    }
}
