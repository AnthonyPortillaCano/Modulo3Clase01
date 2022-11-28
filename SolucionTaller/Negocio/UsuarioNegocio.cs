using Datos.Modelos;
using Datos.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        protected IUsuarioRepository _usuarioRepository;
        public UsuarioNegocio(DbContext dbContext)
        {
            _usuarioRepository=new UsuarioRepository(dbContext);
        }
        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _usuarioRepository.ValidateUser(usuario);
        }
        public async Task<Usuario> ObtenerUsuarioPorEmail(string email)
        {
            return await _usuarioRepository.ObtenerUsuarioPorEmail(email);
        }

        public async Task<Usuario> ObtenerUsuarioPorToken(string token)
        {
            return await _usuarioRepository.ObtenerUsuarioPorToken(token);
        }
        public void UpdateToken(Usuario usuario)
        {
            _usuarioRepository.UpdateToken(usuario);
        }
        public void UpdatePasswordHabilitar(Usuario usuario)
        {
            _usuarioRepository.UpdatePasswordHabilitar(usuario);
        }
        public void UpdateBloqueado(Usuario usuario)
        {
            _usuarioRepository.UpdateBloqueado(usuario);
        }
    }
}