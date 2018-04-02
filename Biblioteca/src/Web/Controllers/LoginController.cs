using System;
using System.Web.Mvc;
using Usuario.Application.Interfaces;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuario usuarioapp;
        public LoginController(IUsuario usu)
        {
            usuarioapp = usu;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(Usuario.Application.ViewModel.Usuario usu) {
            if (ModelState.IsValid)
            {
                usu.Id = Guid.NewGuid();
                usu = usuarioapp.Adicionar(usu);
                TempData["idsuario"] = usu.Id;

                return RedirectToAction("Endereco");
            }
            else
                ModelState.AddModelError("Erro", "Erro no cadastro de dados do cliente");
            return View();
        }

        public ActionResult Endereco() {
            return View();
        }

        public ActionResult RecuperarSenha() {
            return View();
        }

        public ActionResult RedefinirSenha() {
            // vai ser disparado para o e-mail do cliente uma pagina onde vai poder redefinir sua senha de acesso
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RedefinirSenha(Usuario.Application.ViewModel.Usuario usu) {
            
            return View();
        }
    }
}