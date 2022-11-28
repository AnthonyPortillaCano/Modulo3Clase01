using Datos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class UsuarioRepository : RepositoryEF<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
            repositoryEF=new RepositoryEF<Usuario>(context);
        }
        public IRepositoryEF <Usuario> repositoryEF { get; set; }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            Usuario resultado=await repositoryEF.Obtener<Usuario>(a=>a.Email == usuario.Email  && a.Clave==usuario.Clave && a.Bloqueado==false);
            return resultado;
        }
        public async Task<Usuario> ObtenerUsuarioPorEmail(string email)
        {
            Usuario resultado = await repositoryEF.Obtener<Usuario>(a => a.Email == email);
            return resultado;
        }
        public async Task<Usuario>  ObtenerUsuarioPorToken(string token)
        {
            Usuario resultado = await repositoryEF.Obtener<Usuario>(a => a.TokenRecovery == token);
            return resultado;
        }
        public void UpdateToken(Usuario usuario)
        {
            repositoryEF.UpdateFieldsSave(usuario,b=>b.TokenRecovery);
        }
        public void UpdatePasswordHabilitar(Usuario usuario)
        {
            repositoryEF.UpdateFieldsSave(usuario, b => b.Clave, c => c.Bloqueado);
        }
        public void UpdateBloqueado(Usuario usuario)
        {
            repositoryEF.UpdateFieldsSave(usuario, c => c.Bloqueado);
        }
    }
}
