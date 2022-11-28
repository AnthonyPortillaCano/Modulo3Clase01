using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace MVC.Controllers
{
    public class TallerController : BaseController
    {
        public TallerController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
