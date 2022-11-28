using Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class UnitOfWork: IUnitOfWork
    {
        private readonly BDInstitutoContext _context;
        public UnitOfWork(BDInstitutoContext context) 
        { 
            _context= context;
            usuarioNegocio = new UsuarioNegocio(_context);
        }
        public IUsuarioNegocio usuarioNegocio { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
