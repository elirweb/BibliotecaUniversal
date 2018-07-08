using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaria bibliotecaria;
        private readonly IEndereco endereco;
        private List<string> erros = new List<string>();
        private Biblioteca.Core.Domain.Foto.HelperFoto foto = new Biblioteca.Core.Domain.Foto.HelperFoto();


        public BibliotecaController(IBibliotecaria bibli, IEndereco en)
        {
            bibliotecaria = bibli;
            endereco = en;
        }
        // GET: Biblioteca
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            var model = new UsuarioBiblioteca.Application.ViewModel.Bibliotecaria();
            model._liststatus = model.ListStatus();
            return View(model);
        }
        [HttpPost]
        public JsonResult RespostaCadastro(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria model) {

            try
            {
                bibliotecaria.Adicionar(model);
                var ret = foto.ArquivarFoto(model.Imagem);
                var bibli = new List<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria>();
                bibli.Add(model);

                if (model.ListaErros.Count > 0)
                {
                    foreach (var erro in model.ListaErros)
                        erros.Add(erro);

                    return Json(new { Msg = erros }, JsonRequestBehavior.AllowGet);
                }
                else if (!ret)
                {
                    erros.Add("Erro na extensão da imagem");
                    return Json(new { Msg = erros }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TempData["BiblioDados"] = bibli;
                    return Json(new { Msg = "Dados enviados" }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception f)
            {
                return Json(new { Msg = f.InnerException }, JsonRequestBehavior.AllowGet);
            }
          
        }

        public ActionResult Endereco(string token)
        {
            @ViewBag.tk = token;
            var model = new UsuarioBiblioteca.Application.ViewModel.Endereco();
            model._listp = model.ListTipos();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Endereco(UsuarioBiblioteca.Application.ViewModel.Endereco end,FormCollection form) {
            if (ModelState.IsValid)
            {
                TempData.Keep("BiblioDados");
                var biblioteca = (List<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria>)TempData["BiblioDados"];
                foreach (var _bi in biblioteca)
                {
                    var b = new UsuarioBiblioteca.Application.ViewModel.Bibliotecaria()
                    {
                        Id = Guid.NewGuid(),
                        Cnpj = _bi.Cnpj,
                        Senha = _bi.Senha,
                        Email = _bi.Email,
                        RazaoSocial = _bi.RazaoSocial,
                        Situacao = _bi.Situacao,
                        Imagem = _bi.Imagem
                        
                    };
                    //bibliotecaria.Adicionar(b);
                    end.Bibliotecaria.Id = b.Id;
                    endereco.Add(end,b, form["token"]);

                    TempData.Remove("BiblioDados");
                    TempData["msgSucesso"] = "Dados Gravado com sucesso";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Livro() {
            return View();
        }
    }       


}