using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorEmail(string email);

        Task<Usuario> ObtenerUsuarioPorToken(string token);

        void UpdateToken(Usuario usuario);

        void UpdatePasswordHabilitar(Usuario usuario);

        void UpdateBloqueado(Usuario usuario);
    }
}
