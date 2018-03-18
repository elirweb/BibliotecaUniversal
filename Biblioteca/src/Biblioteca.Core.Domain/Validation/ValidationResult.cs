using System.Collections.Generic;

namespace Biblioteca.Core.Domain.Validation
{
    public class ValidationResult
    {
       
        public IEnumerable<ValidationError> Erros { get; }
        public bool IsValid { get; }
        public string Message { get; set; }

        public ValidationResult() { }


        public void Adicionar(ValidationError error) {
        }
        public void Adicionar(params ValidationResult[] validationResults) {
        }
        public void Remover(ValidationError error) {
        }

    }
}
