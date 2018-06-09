
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UsuarioBiblioteca.Test
{
    public class TesteUnidade
    {
        /*
         *Especificação de Teste
            1 - validar o email administrador
        Dominios: Livro, Administrador, Bibliotecaria 

        */

        [Fact]
        public void Admin_Possui_email_Correto() {
            //Arrange
            var ad = new Entidades.Administrador() {
                Email = "teste.com.br"
            };
            //Act
            var validar = ad.Email.Contains("@");
            //Assert
            Assert.True(validar);
        }

        [Fact]
        public void Verificar_Se_CNPJ_EhNulo() {
            //Arrange
            var bibli = new Entidades.Bibliotecaria();
            //Act
            bibli.Email = "";

            //Assert 
            Assert.Empty(bibli.Email);
        }


        [Fact]
        public void Verificar_Qtds_LivrosCadastrado() {
            //Arrange
            var list = new List<Entidades.Livro>();

            //Act
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2"   });
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2" });
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2" });
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2" });
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2" });
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro de teste", Editora = "Erica", IdBiblioteca = new System.Guid(), Id = new System.Guid(), QtdPg = 10, Titulo = "Teste 2" });
       
            //Assert
            Assert.Equal(5, list.Count);
        }

        [Fact]
        public void Usuario_Cadastrardados_RetornarId()
        {
            // Arrange
            var repositorio = new Mock<Interfaces.IBibliotecaRepositorio>();
            var biblioservice = new DomainService.BibliotecaServico(repositorio.Object);
            Guid _idusuario;
            var b = Entidades.Bibliotecaria.BibliotecariaFactory.
                Registrar(Guid.NewGuid(),"Biblioteca","00000000000","elir","1234","elirweb@gmail.com",true);

            //Act
            repositorio.Setup(r => r.AdicionarBiblioteca(b));
            var retorno = biblioservice.RetornaSucesso(b);
            //Assert
            Assert.True(retorno.TransacaoId == b.Id);
            _idusuario = retorno.TransacaoId;
        }
    }
}
