using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos.ViewModel
{
    public class RecoveryPasswordViewModel
    {
        public string Token { get; set; }
        [Required(ErrorMessage ="Ingrese su password")]
        public string Clave { get; set; }

        [Compare("Clave")]
        [Required(ErrorMessage = "Ingrese nuevamemte su password")]
        public string Clave2 { get; set; }
    }
}
