using Emprestimo.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class UsuarioController : ApiController
    {
        public readonly IPedido _repositorio;


        public UsuarioController(IPedido ped)
        {
            _repositorio = ped;
        }
        [HttpPost]
        [Route("registrar-emprestimo")]
        public HttpResponseMessage Registrar(Emprestimo.Application.ViewModel.PedidoViewModel pedido)
        {
            if (pedido == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    _repositorio.Adicionar(pedido);
                    return Request.CreateResponse<Emprestimo.Application.ViewModel.PedidoViewModel>(HttpStatusCode.OK, pedido);

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }

        }
    }
}
