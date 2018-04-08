using System;
using System.Web.Mvc;
using Usuario.Application.Interfaces;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuario usuarioapp;
        private readonly IEndereco enderecoapp;
        public LoginController(IUsuario usu, IEndereco end)
        {
            usuarioapp = usu;
            enderecoapp = end;
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
                if (usu.ListaErros.Count > 0)
                {
                    foreach (var erro in usu.ListaErros)
                        ModelState.AddModelError("Error", erro);
                }
                else {
                    TempData["idusuario"] = usu.Id;
                    return RedirectToAction("Endereco");
                }
            }
            else
                ModelState.AddModelError("Error", "Erro no cadastro de dados do cliente");

            return View();
        }

        public ActionResult Endereco() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Endereco(Usuario.Application.ViewModel.EnderecoUsuario endereco) {
            Guid ids = Guid.NewGuid();

            if (Guid.TryParse(TempData["idusuario"].ToString(), out ids))
                endereco.IdUsuario.Id = ids;

            if (ModelState.IsValid)
            {
                enderecoapp.Adicionar(endereco);
                TempData.Remove("idusuario");
                TempData["msgSucesso"] = "Dados Gravado com sucesso";
                return RedirectToAction("index");
            }
            else
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