using Microsoft.AspNetCore.Mvc;
using Schedule.Repository;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorRepository _repository;

        public TarefaController(OrganizadorRepository context)
        {
            _repository = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var tarefa = await _repository.ObterPorId(id);
            return tarefa == null ? NotFound() : Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _repository.ObterTodos());
        }

        [HttpGet("ObterPorTitulo")]
        public async Task<IActionResult> ObterPorTitulo(string titulo)
        {
            var tarefa = await _repository.ObterPorTitulo(titulo);
            return tarefa == null ? NotFound() : Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public async Task<IActionResult> ObterPorData(DateTime data)
        {
            var tarefa = await _repository.ObterPorData(data);
            return tarefa == null ? NotFound() : Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public async Task<IActionResult> ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = await _repository.ObterPorStatus(status);
            return tarefa == null ? NotFound() : Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa tarefa)
        {
            await _repository.Criar(tarefa);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Tarefa tarefa)
        {
            await _repository.Atualizar(id, tarefa);
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _repository.Deletar(id);
            return Ok();
        }
    }
}
