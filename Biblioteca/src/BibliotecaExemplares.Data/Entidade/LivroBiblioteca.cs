using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaExemplares.Data.Entidade
{
    public class LivroBiblioteca
    {
        public LivroBiblioteca()
        {
            this.Exemplar = new HashSet<Exemplares.Domain.Entidade.Livro>();
            this.Bibliotecas = new HashSet<UsuarioBiblioteca.Entidades.Bibliotecaria>();
        }
        
        [Key]
        public Guid LivBId { get; set; }

        public ICollection<Exemplares.Domain.Entidade.Livro> Exemplar { get; set; }
        public  ICollection<UsuarioBiblioteca.Entidades.Bibliotecaria> Bibliotecas { get; set; }

    }
}
