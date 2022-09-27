using TrilhaApiDesafio.Models;

namespace Schedule.Repository.Interface
{
    public interface IRepository<T>
    {
        Task<T> ObterPorId(int id);

        Task<IEnumerable<T>> ObterTodos();

        Task<T> ObterPorTitulo(string titulo);

        Task<T> ObterPorData(DateTime data);

        Task<T> ObterPorStatus(EnumStatusTarefa status);

        Task Criar(Tarefa tarefa);
        Task Atualizar(int id, Tarefa tarefa);

        Task Deletar(int id);
    }
}