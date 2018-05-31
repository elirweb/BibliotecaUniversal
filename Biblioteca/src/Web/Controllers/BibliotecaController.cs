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
            return View();
        }

        public JsonResult RespostaCadastro(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria bi, string token) {
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