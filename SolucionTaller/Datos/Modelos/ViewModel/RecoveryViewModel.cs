using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Modelos.ViewModel
{
    public class RecoveryViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage ="Ingrese su correo")]
        public string Email { get; set; }
    }
}
