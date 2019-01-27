using Emprestimo.Application.Interfaces;
using Emprestimo.Application.ViewModel;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [Authorize(Roles = "pedido")]
    [RoutePrefix("pedido/Gestao")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class PedidoController : ApiController
    {
        public readonly IPedido _repositorio;
        public PedidoController(IPedido ped)
        {
            _repositorio = ped;
        }

        [HttpPost]
        [Route("registrar-emprestimo")]
        public HttpResponseMessage Registrar(PedidoViewModel pedido)
        {
            if (pedido == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    _repositorio.Adicionar(pedido);
                    return Request.CreateResponse<PedidoViewModel>(HttpStatusCode.OK, pedido);

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }

        }
    }
}
