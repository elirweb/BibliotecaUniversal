using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaria _bibliotecaria;
        private readonly IEndereco _endereco;
        private readonly ILivro _livro; 
        private List<string> erros = new List<string>();
        private Biblioteca.Core.Domain.Foto.HelperFoto _foto = new Biblioteca.Core.Domain.Foto.HelperFoto();
        private string retorno = string.Empty;

        public BibliotecaController(IBibliotecaria bibli, IEndereco en,ILivro lv)
        {
            _bibliotecaria = bibli;
            _endereco = en;
            _livro = lv;

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
        public ActionResult RespostaCadastro(FormCollection model) {
            //os dados vão vim e chamar a api 
            // 1 gravar a foto
            //gravar os dados em uma sessão 

            
            return Json(new { Msg = erros }, JsonRequestBehavior.AllowGet);
        
        
    }

        public ActionResult Endereco()
        {
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
                    //gravar os dados na api passando o endereço e a biblioteca

                    
                    return View();
                }
            }
            else
                ModelState.AddModelError("Error", retorno);

            return View();
        }

        public ActionResult Livro() {
           
            var model = new UsuarioBiblioteca.Application.ViewModel.Livro();
            model._listlv = model.ListCategoria();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Livro( FormCollection form) {
            //gravar os dados na api 
             return View();
        }

        public ActionResult Lista() {
            return View();
        }

        public ActionResult DadosBilioteca() {
            return View();
        }

        
    }       


}