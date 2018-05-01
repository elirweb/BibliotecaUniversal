using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Usuario.Test
{
    public class TesteUnidade
    {
        /* Especificação de teste de unidade 
         1 - validar se o usuario digitou usuario e senha 
         2 - verificar se o email do usuario consta no banco de dados
         3 - verificar se o usuario preencheu todos os campos do cadastro
         4 - Gravação de dados   
         */


        public Entidade.Usuario usuario = null;
        public TesteUnidade()
        {
            usuario = new Entidade.Usuario() {
                Email = "elirweb@gmail.com",
                Senha = "",
                Login = "",
                ConfirmaSenha = "******",
                Grupo = "Usuario",
                Nome = "Elir",
                Cpf = "11111111111"
            };
        }
        [Fact]
        public void Usuario_informou_login_senha() {
            //Arrange
            //Act
            bool r = false;
            if (usuario.Login != string.Empty && usuario.Senha != string.Empty)
                r = true;
            //Assert
            Assert.True(r);
        }

        [Fact]
        public void Usuario_Cadastrardados_RetornarId() {
            // Arrange
            var repositorio = new Mock<Interfaces.IUsuarioRepositorio>();
            var usuarioservice = new DomainService.UsuarioServico(repositorio.Object);
            Guid _idusuario;
            var usuario = Entidade.Usuario.UsuarioFactory.
                NovoUsuario(Guid.NewGuid(), "Elir", "elirweb@gmail.com", "1234");

            //Act
            repositorio.Setup(r => r.AdicionarUsuario(usuario));
            var retorno = usuarioservice.RetornaSucesso(usuario);
            //Assert
            Assert.True(retorno.TransacaoId == usuario.IdUsuario);
            _idusuario = retorno.TransacaoId;
        }

        [Fact]
        public void Usuario_login_senha_ConstanoBanco_true() {
            //Arrange
            var list = new List<Entidade.Usuario>();
            list.Add(new Entidade.Usuario() { Login = "elir",Senha="********" });
            list.Add(new Entidade.Usuario() { Login = "joao", Senha = "********" });
            list.Add(new Entidade.Usuario() { Login = "maria", Senha = "********" });
            list.Add(new Entidade.Usuario() { Login = "roberto", Senha = "********" });
            list.Add(new Entidade.Usuario() { Login = "joaquim", Senha = "********" });

            //Act
            var usuario = list.Where(c => c.Login.Equals("elir") && c.Senha.Equals("1234"));
            bool encontrar = false;
            if (usuario != null)
                encontrar = true;

            //Assert
            Assert.True(encontrar);
        }

    }
}
