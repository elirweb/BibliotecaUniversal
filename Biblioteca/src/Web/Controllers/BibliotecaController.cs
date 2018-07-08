using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Web.Controllers
{
    public class BibliotecaController : Controller
    {
  
        // GET: Biblioteca
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()//cadastro de biblioteca 
        {
            var model = new UsuarioBiblioteca.Application.ViewModel.Bibliotecaria();
            model._liststatus = model.ListStatus();
            return View(model);
        }
        [HttpPost]
        public JsonResult RespostaCadastro(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria model) {
            //este cara responsavel por receber viewmodel e token para passar para api responsavel do cadastro

            return Json(new { Sucesso = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Endereco()
        {
            return View();
        }

       

        public ActionResult Livro() {
            return View();
        }
    }       


}