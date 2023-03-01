using Microsoft.EntityFrameworkCore;

namespace ApiArcadeScore.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        { }
        public DbSet<Jogadores> Jogadores { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }
        public DbSet<JogadorRanking> JogadorRanking { get; set; }
        public DbSet<Estatistica> Estatistica { get; set; }
    }
}
