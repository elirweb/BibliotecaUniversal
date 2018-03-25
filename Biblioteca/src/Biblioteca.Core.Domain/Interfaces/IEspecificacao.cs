namespace Biblioteca.Core.Domain.Interfaces
{
    public interface IEspecificacao<T>
    {
        bool Satisfeito(T model); 
    }
}
