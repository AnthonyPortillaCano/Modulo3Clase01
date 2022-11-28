using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace MVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        public BaseController  (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
