using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class LoginBibliotecaController : Controller
    {
     
        private readonly IAdministrador _admin;
        private List<string> erros = new List<string>();
        public LoginBibliotecaController(IAdministrador adm)
        {
            _admin = adm;
        }
        // GET: LoginBiblioteca
        public ActionResult Index()
        {
            ViewBag.TitlePag = "Administrador";
            return View();
        }

        public ActionResult CadAdministrador()
        {
            ViewBag.TitlePag = "Administrador";
            return View();

        }

      
        public ActionResult RespostaAdm(FormCollection model)
        {
            try
            {
                var adm = new UsuarioBiblioteca.Application.ViewModel.Administrador()
                {
                    Nome = model["Nome"],
                    Email = model["Email"],
                    Senha = model["Senha"],
                    ConfirmaSenha = model["ConfirmaSenha"],
                    Login = model["Login"]
                };
                _admin.Adicionar(adm);

                if (adm.ListaErros.Count > 0)
                {
                    foreach (var erro in adm.ListaErros)
                        erros.Add(erro);
                    return Json(new { Msg = erros }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Msg = "Dados Cadastrado com sucesso" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception f)
            {

                return Json(new { Msg = f.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult RecuperarSenha()
        {
            ViewBag.TitlePag = "Administrador";
            return View();
        }

       

        public ActionResult RedefinirSenha()
        {
            ViewBag.TitlePag = "Administrador";
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