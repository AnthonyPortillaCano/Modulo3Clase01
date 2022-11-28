using Datos.Modelos;
using Datos.Modelos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using MVC.Util;
using Negocio;

namespace MVC.Controllers
{
    public class SeguridadController : BaseController
    {
        protected readonly IConfiguration _configuration;
        int count = 0;
        public SeguridadController(IUnitOfWork unitOfWork,IConfiguration configuration) : base(unitOfWork)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] Usuario usuario)
        {
            var resultado = await _unitOfWork.usuarioNegocio.ValidateUser(usuario);
            if(resultado==null)
            {
                count++;
                return RedirectToAction("Index");
            }
            else if(count>2)
            {
                usuario.Bloqueado = true;
                _unitOfWork.usuarioNegocio.UpdateBloqueado(usuario);
                ViewBag.MensajeError = "Se bloqueo su cuenta";
            }
            else
            {
                return RedirectToAction("Index", "Taller");
            }
            return View();
        }
        public IActionResult StartRecovery()
        {
            RecoveryViewModel recoveryViewModel = new();
            return View(recoveryViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> StartRecovery(RecoveryViewModel recoveryViewModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(recoveryViewModel);
                }
                Common common = new();
                string token=common.GetSHA256(Guid.NewGuid().ToString());
                Usuario usuario=await _unitOfWork.usuarioNegocio.ObtenerUsuarioPorEmail(recoveryViewModel.Email);
                if(usuario!=null)
                {
                    usuario.TokenRecovery = token;
                    _unitOfWork.usuarioNegocio.UpdateToken(usuario);
                    await _unitOfWork.CommitAsync();
                    var UrlBase = _configuration["Url"];
                    var urlFinal = UrlBase + "Seguridad/Recovery?token=" + token;
                    await common.SendEmailAsync(usuario.Email, urlFinal);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
        public async Task<IActionResult> Recovery(string token)
        {
            RecoveryPasswordViewModel recoveryPasswordViewModel = new();
            recoveryPasswordViewModel.Token = token;
            if(recoveryPasswordViewModel.Token==null && recoveryPasswordViewModel.Token.Trim().Equals(""))
            {
                return View("Index");
            }
            Usuario usuario = await _unitOfWork.usuarioNegocio.ObtenerUsuarioPorToken(recoveryPasswordViewModel.Token);
            if(usuario==null)
            {
                ViewBag.Error = "Tu token ha expirado";
                return View("Index");
            }
            return View(recoveryPasswordViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Recovery(RecoveryPasswordViewModel recoveryPasswordViewModel)
        {
            try
            {
                Usuario usuario = await _unitOfWork.usuarioNegocio.ObtenerUsuarioPorToken(recoveryPasswordViewModel.Token);
                if(usuario!=null)
                { 
                   usuario.Clave=recoveryPasswordViewModel.Clave;
                    usuario.Bloqueado = false;
                    _unitOfWork.usuarioNegocio.UpdatePasswordHabilitar(usuario);
                    await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ViewBag.Message = "La clave se ha modificado con exito";
            return View(recoveryPasswordViewModel);
        }
    }
}
