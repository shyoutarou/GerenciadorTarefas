using Microsoft.EntityFrameworkCore;
using Schedule.Repository.Interface;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace Schedule.Repository
{
    public class OrganizadorRepository : IRepository<Tarefa>
    {
        private readonly OrganizadorContext _context;

        public OrganizadorRepository(OrganizadorContext context)
        {
            _context = context;
        }

        public async Task Atualizar(int id, Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return;

            var tarefaExistente = await ObterPorId(tarefa.Id);

            if (tarefaExistente == null)
                return;

            _context.Tarefas.Update(tarefa);

            await _context.SaveChangesAsync();
        }

        public async Task Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return;

            var tarefaExistente = await ObterPorId(tarefa.Id);

            if (tarefaExistente != null)
                return;

            _context.Tarefas.Add(tarefa);

            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var tarefa = await ObterPorId(id);

            if (tarefa == null)
                return;

            _context.Tarefas.Remove(tarefa);

            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa> ObterPorData(DateTime data)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Data == data);
        }

        public async Task<Tarefa> ObterPorId(int id)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Id == id);
        }

        public async Task<Tarefa> ObterPorStatus(EnumStatusTarefa status)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Status == status);
        }

        public async Task<Tarefa> ObterPorTitulo(string titulo)
        {
            return await _context.Tarefas.FirstOrDefaultAsync(tarefa => tarefa.Titulo.ToUpper() == titulo.ToUpper());
        }

        public async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await _context.Tarefas.ToListAsync();
        }
    }
}