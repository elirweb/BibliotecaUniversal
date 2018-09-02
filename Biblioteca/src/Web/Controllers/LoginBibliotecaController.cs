using System.Collections.Generic;
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
            if (ModelState.IsValid)
            {

                var Listbibli = new List<UsuarioBiblioteca.Application.ViewModel.Administrador>();
                Listbibli.Add(adm);
                adm = admin.Adicionar(adm);
                if (adm.ListaErros.Count > 0)
                {
                    foreach (var erro in adm.ListaErros)
                        ModelState.AddModelError("Error", erro);
                }
                else
                {
                    TempData["msgSucesso"] = "Dados cadastrado com sucesso";
                    return RedirectToAction("Index", "LoginBiblioteca");
                }
            }
            else
                ModelState.AddModelError("Error", "Erro no cadastro de dados do Administrador");

            return View();
        }
                
      
        public ActionResult RecuperarSenha()
        {

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