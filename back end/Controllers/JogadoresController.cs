using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiArcadeScore.Models;

namespace ApiArcadeScore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly ApiContext _context;

        public JogadoresController(ApiContext context)
        {
            _context = context;
            AdicionarDadosTeste(_context);
        }

        // GET: api/Jogadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogadores>>> GetJogadores()
        {
            return await _context.Jogadores.ToListAsync();
        }

        // GET: api/Jogadores
        [HttpGet]
        [Route("JogadoresRanking")]
        public async Task<ActionResult<IEnumerable<JogadorRanking>>> GetJogadoresRanking()
        {
            var lista = await Task.FromResult(_context.Pontuacao
            .Join(_context.Jogadores, p => p.JogadorId, j => j.Id, (p, j) => new { p, j })
            .GroupBy(g => new { g.j.Id, g.j.Nome})
            .Select(r => new JogadorRanking
            {
               Id = r.Key.Id,
               Nome = r.Key.Nome,
               Pontos = r.Sum(g => g.p.Pontos)
            }).OrderByDescending(o=> o.Pontos)).Result.ToListAsync();
            return lista;
        }


        // POST: api/Jogadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jogadores>> PostJogadores(Jogadores jogadores)
        {
            _context.Jogadores.Add(jogadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogadores", new { id = jogadores.Id }, jogadores);
        }

        // DELETE: api/Jogadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogadores(int id)
        {
            var jogadores = await _context.Jogadores.FindAsync(id);
            if (jogadores == null)
            {
                return NotFound();
            }

            _context.Jogadores.Remove(jogadores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogadoresExists(int id)
        {
            return _context.Jogadores.Any(e => e.Id == id);
        }


        private static void AdicionarDadosTeste(ApiContext context)
        {
            if (context.Jogadores.Count() > 0) return;

            List<Jogadores> listajogadores = new List<Jogadores>{
                   new Jogadores{Id = 1, Nome ="Jogador 1"},
                   new Jogadores{Id = 2, Nome ="Jogador 2"},
                   new Jogadores{Id = 3, Nome ="Jogador 3"},
                   new Jogadores{Id = 4, Nome ="Jogador 4"},
                   new Jogadores{Id = 5, Nome ="Jogador 5"},
                   new Jogadores{Id = 6, Nome ="Jogador 6"},
                   new Jogadores{Id = 7, Nome ="Jogador 7"},
                   new Jogadores{Id = 8, Nome ="Jogador 8"},
                   new Jogadores{Id = 9, Nome ="Jogador 9"},
                   new Jogadores{Id = 10, Nome ="Jogador 10"},
                   };

            foreach (Jogadores jogador in listajogadores)
            {
                context.Jogadores.Add(jogador);
            }
            context.SaveChanges();
        }
    }
}
