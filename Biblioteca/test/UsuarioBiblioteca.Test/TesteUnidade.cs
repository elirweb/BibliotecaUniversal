
using System.Collections.Generic;
using Xunit;

namespace UsuarioBiblioteca.Test
{
    public class TesteUnidade
    {
        /*
         *Especificação de Teste
            
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
        public void Cadastrar_3_Livros_True() {
            //Arrange
            var list = new List<Entidades.Livro>();
            list.Add(new Entidades.Livro() { Ativo = true, Descricao = "Livro muito bom", Editora = "Erica", QtdPg = 200, Titulo = "elirweb"  });

            //Act
            var count = list.Count;

            //Assert 
            Assert.Equal("3", count.ToString());
        }
    }
}
