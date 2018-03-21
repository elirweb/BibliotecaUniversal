using Biblioteca.Core.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exemplares.Domain.Entidade
{
    public class Livro : Base.BasePrincipal
    {
        public string Codigo { get; private set; }
        public string Titulo { get; private set; }
        public DateTime DtCadastro { get; private set; }
        public string Descricao { get; private set; }
        public TimeSpan HoraCadastro { get; private set; }
        public int QtdPagina { get; private set; }
        public ValueObject.TipoArea Area { get; private set; }
        public virtual UsuarioBiblioteca.Entidades.Bibliotecaria Biblioteca { get; private set; }
        public string Capa { get; private set; }
        public Guid IdBiblioteca { get; private set; }
        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        public Livro(Livro lv)
        {
            Codigo = lv.Codigo;
            Titulo = lv.Titulo;
            DtCadastro = lv.DtCadastro;
            Descricao = lv.Descricao;
            HoraCadastro = lv.HoraCadastro;
            QtdPagina = lv.QtdPagina;
            Area = lv.Area;
            IdBiblioteca = lv.IdBiblioteca;
        }
    }
}
