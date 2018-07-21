using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaria bibliotecaria;
        private readonly IEndereco endereco;
        private readonly ILivro livro; 
        private List<string> erros = new List<string>();
        private Biblioteca.Core.Domain.Foto.HelperFoto foto = new Biblioteca.Core.Domain.Foto.HelperFoto();
        private string retorno = string.Empty;

        public BibliotecaController(IBibliotecaria bibli, IEndereco en,ILivro lv)
        {
            bibliotecaria = bibli;
            endereco = en;
            livro = lv;

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
                    erros.Add("Erro no envio da imagem");
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
                    end.Bibliotecaria.Id = b.Id;
                    endereco.Add(end,b, form["token"], out retorno);
                    if (retorno.Equals("erro"))
                        ModelState.AddModelError("Error", retorno);
                    else {
                            TempData.Remove("BiblioDados");
                            TempData["msgSucesso"] = "Dados Gravado com sucesso";
                    }
                    return View();
                }
            }
            else
                ModelState.AddModelError("Error", retorno);

            return View();
        }

        public ActionResult Livro(string token) {
            @ViewBag.tk = token;
            var model = new UsuarioBiblioteca.Application.ViewModel.Livro();
            model._listlv = model.ListCategoria();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Livro(UsuarioBiblioteca.Application.ViewModel.Livro lv, FormCollection form) {
            
            if (ModelState.IsValid)
                 livro.add(lv, form["token"], out retorno);
            else
                ModelState.AddModelError("Error", retorno);
            return View();
        } 

        
    }       


}