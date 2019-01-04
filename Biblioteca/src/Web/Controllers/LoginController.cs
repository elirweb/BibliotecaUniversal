using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Usuario.Application.Interfaces;

namespace Web.Controllers
{
    public class LoginController : Controller
    { 
        private readonly IUsuario _usuarioapp;
        private readonly IEndereco _enderecoapp;
        private List<string> erros = new List<string>();
        public LoginController(IUsuario usu, IEndereco end)
        {
            _usuarioapp = usu;
            _enderecoapp = end;
        }

        // GET: Login dd
        public ActionResult Index()
        {
            ViewBag.TitlePag = "Usuário";
            return View();
        }
        

        public ActionResult Cadastro() {
            ViewBag.TitlePag = "Cadastro";

            return View();
        }

        [HttpPost]
       
        public ActionResult Cadastro(FormCollection model) {

            try
            {
                var usu = new Usuario.Application.ViewModel.Usuario()
                {
                    Nome = model["Nome"],
                    Email = model["Email"],
                    Login = model["Login"],
                    Cpf = model["Cpf"],
                    Senha = model["Senha"],
                    ConfirmaSenha = model["Senha"]
                };

                var ListUser = new List<Usuario.Application.ViewModel.Usuario>
                {
                    usu
                };
                TempData["DadosUsuario"] = ListUser;
                usu = _usuarioapp.Adicionar(usu);
                if (usu.ListaErros.Count > 0)
                {
                    
                    usu.ListaErros.ForEach(x => erros.Add(x));
                    return Json(new { Msg = erros }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { Msg = "Dados enviado com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception f)
            {

                return Json(new { Msg = f.Message }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult Endereco() {
            ViewBag.TitlePag = "Endereço";
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
                    _usuarioapp.Adicionar(u);
                    endereco.IdUsuario.Id = u.Id;
                }
                
                _enderecoapp.Adicionar(endereco);
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

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarSenha(Usuario.Application.ViewModel.Usuario usu)
        {
            if (usu.Email != string.Empty) {
                if (_usuarioapp.RecuperarSenha(usu.Email))
                    ViewBag.Msg = "Olá foi enviado e-mail para redefir sua senha de acesso!";
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

            if (_usuarioapp.Redefirsenha(usu.Email, usu.Senha)) 
                ViewBag.Msg = "Olá Senha alterada com sucesso";
            else
                ModelState.AddModelError("Error", "Erro na alteração de Senha");
            return View();
        }
    }
}