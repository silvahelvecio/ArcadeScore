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
    public class PontuacaoController : ControllerBase
    {
        private readonly ApiContext _context;

        public PontuacaoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Pontuacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pontuacao>>> GetPosts()
        {
            return await _context.Pontuacao.ToListAsync();
        }

        // GET: api/Pontuacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pontuacao>> GetPontuacao(int id)
        {
            var pontuacao = await _context.Pontuacao.FindAsync(id);

            if (pontuacao == null)
            {
                return NotFound();
            }

            return pontuacao;
        }

        // GET: api/Pontuacao/5
        [HttpGet]
        [Route("EstatisticaJogador")]
        public async Task<ActionResult<List<Estatistica>>> GetEstatisticaJogador(int id)
        {
            var estatistica = await Task.FromResult(_context.Pontuacao.Where(c=> c.JogadorId== id)
            .GroupBy(g => new { g.JogadorId })
            .Select(r => new Estatistica
            {
                JogadorId = r.Key.JogadorId,
                PartidasJogadas = r.Count(),
                MediaPontuacao = r.Sum(m => m.Pontos) / r.Count(),
                MaiorPontuacao = r.Max(m => m.Pontos),
                MenorPontuacao = r.Min(m => m.Pontos),
                QtdeVezesRecord = r.Select(m=>m.Pontos).Distinct().Count(),
                TempoJoga = Math.Round((DateTime.Now - r.Min(m => m.Data)).TotalDays/30,1) 
            })).Result.ToListAsync();
            return estatistica;
        }

        // PUT: api/Pontuacao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPontuacao(int id, Pontuacao pontuacao)
        {
            if (id != pontuacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(pontuacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PontuacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pontuacao
        [HttpPost]
        public async Task<ActionResult<Pontuacao>> PostPontuacao(Pontuacao pontuacao)
        {
            _context.Pontuacao.Add(pontuacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPontuacao", new { id = pontuacao.Id }, pontuacao);
        }

        // DELETE: api/Pontuacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePontuacao(int id)
        {
            var pontuacao = await _context.Pontuacao.FindAsync(id);
            if (pontuacao == null)
            {
                return NotFound();
            }

            _context.Pontuacao.Remove(pontuacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PontuacaoExists(int id)
        {
            return _context.Pontuacao.Any(e => e.Id == id);
        }
    }
}
