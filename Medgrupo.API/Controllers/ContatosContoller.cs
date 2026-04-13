using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medgrupo.API.Data;
using Medgrupo.Domain;

namespace Medgrupo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContatosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/contatos (Criar Novo Contato)
        [HttpPost]
        public async Task<IActionResult> Create(Contato contato)
        {
            var validacao = contato.Validar();

            if (!validacao.Valid)
            {
                // Retorna exatamente qual requisito (1b, 1c ou 1d) foi violado
                return BadRequest(new { erro = validacao.Error });
            }

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);
        }

        // GET: api/contatos (Listar todos - o filtro de ativos já é global)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetAll()
        {
            return await _context.Contatos.ToListAsync();
        }

        // GET: api/contatos/{id} (Visualizar detalhes)
        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetById(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
                return NotFound(new { message = "Contato não encontrado ou inativo." });

            return contato;
        }

        // PUT: api/contatos/{id}/desativar (Desativar Contato)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contato contato)
        {
            if (id != contato.Id) return BadRequest();

            var validacao = contato.Validar();
            if (!validacao.Valid) return BadRequest(new { message = validacao.Error });

            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/contatos/{id}/ativar (Ativar)
        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> Ativar(int id)
        {
            // Usamos IgnoreQueryFilters para conseguir achar um contato que está inativo
            var contato = await _context.Contatos.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);

            if (contato == null) return NotFound();

            contato.Ativo = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/contatos/{id} (Excluir Contato)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Ignore o filtro global para poder achar e deletar fisicamente se necessário
            var contato = await _context.Contatos.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);

            if (contato == null) return NotFound();

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}