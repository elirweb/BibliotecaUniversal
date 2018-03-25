using Biblioteca.Core.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Validacao
{
    public class BibliotecaAptoParaCadastro: Validator<Entidades.Bibliotecaria>
    {
        
        public BibliotecaAptoParaCadastro(Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio)
        {
            var cnpj = new Especificacao.BibliotecaDevePossuiCNPJUnico(repositorio);
            var emailunico = new Especificacao.BibliotecaDevePossuirUnicoEmail(repositorio);

            base.Add("cnpj", new Rule<Entidades.Bibliotecaria>(cnpj,"Cnpj já existe"));
            base.Add("email", new Rule<Entidades.Bibliotecaria>(emailunico, "E-mail já existe"));
        }

        
    }
}
