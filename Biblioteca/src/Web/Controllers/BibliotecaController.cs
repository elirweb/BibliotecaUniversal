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
        private readonly List<string> erros = new List<string>();
        private readonly Biblioteca.Core.Domain.Foto.HelperFoto _foto = new Biblioteca.Core.Domain.Foto.HelperFoto();
        private readonly Biblioteca.Core.Domain.Util.RegistrarDados _registrar = new Biblioteca.Core.Domain.Util.RegistrarDados();
        private readonly Biblioteca.Core.Domain.Util.RetornarDados _retornar = new Biblioteca.Core.Domain.Util.RetornarDados();

        private readonly string retorno = string.Empty;

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
            var _biblio = new UsuarioBiblioteca.Application.ViewModel.Bibliotecaria() {
                RazaoSocial = model["RazaoSocial"],
                Cnpj = model["cnpj"],
                Email = model["email"],
                Usuario = model["Usuario"],
                Imagem = Request.Files["Imagem"].FileName,
                Senha = model["Senha"],
                ConfirmaSenha = model["ConfirmaSenha"]
            };
            List<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria> b = new List<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria>
            {
                _biblio
            };
            _foto.ArquivarFoto(Request.Files["Imagem"]);
            TempData["BiblioDados"] = b;
            TempData["token"] = model["token"];
            return Json(new { Msg = "Dados enviados" }, JsonRequestBehavior.AllowGet);
        
        
    }

        public ActionResult Endereco()
        {
            var model = new UsuarioBiblioteca.Application.ViewModel.Endereco();
            model._listp = model.ListTipos();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Endereco(UsuarioBiblioteca.Application.ViewModel.Endereco end) {
            if (ModelState.IsValid) {
                TempData.Keep("BiblioDados");
                TempData.Keep("token");
                string token = TempData["token"].ToString();
                var biblioteca = (List<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria>)TempData["BiblioDados"];
                foreach (var _bi in biblioteca)
                {
                    var b = new UsuarioBiblioteca.Application.ViewModel.Bibliotecaria()
                    {
                        Id = Guid.NewGuid(),
                        Cnpj = _bi.Cnpj,
                        Senha = _bi.Senha,
                        ConfirmaSenha = _bi.ConfirmaSenha,
                        Email = _bi.Email,
                        RazaoSocial = _bi.RazaoSocial,
                        Situacao = _bi.Situacao,
                        Imagem = _bi.Imagem,
                        Usuario = _bi.Usuario

                    };
                  
                    try
                    {
                        var retorno = _registrar.PostDados<UsuarioBiblioteca.Application.ViewModel.Bibliotecaria>(System.Configuration.ConfigurationManager.AppSettings["urlweb"] + "biblioteca/Gestao/registrar-biblioteca", token, b);
                        if (retorno.Result.ListaErros.Count > 0)
                        {
                            foreach (var erro in retorno.Result.ListaErros)
                                erros.Add(erro);
                            ViewBag.Msg = erros;
                        }
                        else
                        {
                            end.Bibliotecaria.Id = retorno.Result.Id;
                            var x = _registrar.PostDados<UsuarioBiblioteca.Application.ViewModel.Endereco>(System.Configuration.ConfigurationManager.AppSettings["urlweb"] + "biblioteca/Gestao/registrar-endereco", token, end);
                            erros.Add("Dados enviados com sucesso");
                            ViewBag.Msg = erros;

                        }
                        var model = new UsuarioBiblioteca.Application.ViewModel.Endereco();
                        model._listp = model.ListTipos();
                         
                        return View(model);

                    }
                    catch (Exception e)
                    {

                        throw new Exception(e.Message);
                    }
                }

            }
                return View();
        }

        public ActionResult Livro() {
           //chamar a api de
            var model = new UsuarioBiblioteca.Application.ViewModel.Livro();
            ViewBag.tokenlivro = string.Empty;

            model._listlv = model.ListCategoria();
            model.ListBiblioteca = _livro.DropBiblioteca(); 
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Livro(FormCollection form) {

            try
            {
                UsuarioBiblioteca.Application.ViewModel.Livro model = null;

                if (ModelState.IsValid)
                {
                    var livro = new UsuarioBiblioteca.Application.ViewModel.Livro()
                    {
                        Ativo = true,
                        IdBiblioteca = Guid.Parse(form["IdBiblioteca"]),
                        Titulo = form["Titulo"],
                        Descricao = form["Descricao"],
                        Editora = form["Editora"],
                        QtdPg = Convert.ToInt32(form["QtdPg"]),
                        DescCategoria = form["DescCategoria"],
                        Id = Guid.NewGuid()


                    };
                    var retorno = _registrar.PostDados<UsuarioBiblioteca.Application.ViewModel.Livro>(System.Configuration.ConfigurationManager.AppSettings["urlweb"] + "Livro/Gestao/registrar-livro", form["tokenlivro"], livro);
                    if (retorno.Result.ListaErros.Count > 0)
                    {

                        foreach (var erro in retorno.Result.ListaErros)
                            erros.Add(erro);
                        ViewBag.Msg = erros;
                    }

                    model = new UsuarioBiblioteca.Application.ViewModel.Livro();
                    model._listlv = model.ListCategoria();
                    model.ListBiblioteca = _livro.DropBiblioteca();
               
                }
                return View(model);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
           
        }

        public ActionResult Lista() {
            return View();
        }

        public ActionResult EditarLivro(Guid idlivro) {
            return View();
        }
        

        
    }       


}