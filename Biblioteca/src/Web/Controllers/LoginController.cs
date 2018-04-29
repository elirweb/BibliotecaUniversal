using System;
using System.Collections.Generic;
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

        // GET: Login dd
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
                var ListUser = new List<Usuario.Application.ViewModel.Usuario>();
                ListUser.Add(usu);
                TempData["DadosUsuario"] = ListUser;
                usu = usuarioapp.Adicionar(usu);
                if (usu.ListaErros.Count > 0)
                {
                    foreach (var erro in usu.ListaErros)
                        ModelState.AddModelError("Error", erro);
                }
                else 
                    return RedirectToAction("Endereco");
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
          
            if (ModelState.IsValid)
            {
                TempData.Keep("DadosUsuario");
                var DadosUsuario = (List<Usuario.Application.ViewModel.Usuario>)TempData["DadosUsuario"];
                foreach (var _usuario in DadosUsuario) {
                    var u = new Usuario.Application.ViewModel.Usuario()
                    {
                        Id = Guid.NewGuid(),
                        Cpf = _usuario.Cpf,
                        Nome = _usuario.Nome,
                        Login = _usuario.Login,
                        Senha = _usuario.Senha,
                        ConfirmaSenha = _usuario.ConfirmaSenha,
                        Email = _usuario.Email
                        
                    };
                    usuarioapp.Adicionar(u);
                    endereco.IdUsuario.Id = u.Id;
                }
                
                enderecoapp.Adicionar(endereco);
                TempData.Remove("DadosUsuario");
                TempData["msgSucesso"] = "Dados Gravado com sucesso";
                return RedirectToAction("index");
            }
            else
                return View();
        }

        public ActionResult RecuperarSenha() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarSenha(Usuario.Application.ViewModel.Usuario usu)
        {
            if (usu.Email != string.Empty) {
                if (usuarioapp.RecuperarSenha(usu.Email))
                    TempData["msgSucesso"] = "Olá foi enviado e-mail para redefir sua senha!";
                else
                    ModelState.AddModelError("Error", "E-mail não cadastrado em nosso banco de dados");
            }
            return View();
        }

        public ActionResult RedefinirSenha() {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RedefinirSenha(Usuario.Application.ViewModel.Usuario usu) {

            if (usuarioapp.Redefirsenha(usu.Email, usu.Senha)) 
                TempData["msgSucesso"] = "Olá Senha alterada com sucesso";
            else
                ModelState.AddModelError("Error", "Erro na alteração de Senha");
            return View();
        }
    }
}