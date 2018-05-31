using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class LoginBibliotecaController : Controller
    {
     
        private readonly IAdministrador admin;
        public LoginBibliotecaController(IAdministrador adm)
        {
            admin = adm;
        }
        // GET: LoginBiblioteca
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadAdministrador()
        {
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CadAdministrador(UsuarioBiblioteca.Application.ViewModel.Administrador adm)
        {
            if (ModelState.IsValid) { }
                return View();
        }

        public ActionResult RecuperarSenha()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RecuperarSenha(UsuarioBiblioteca.Application.ViewModel.Administrador adm)
        {
            if (ModelState.IsValid) { }
            return View();
        }

        public ActionResult RedefinirSenha()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RedefinirSenha(UsuarioBiblioteca.Application.ViewModel.Administrador adm)
        {
            if (ModelState.IsValid) { }
            return View();
        }

    }
}