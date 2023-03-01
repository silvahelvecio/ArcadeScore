using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiArcadeScore.Models
{
    public class JogadorRanking
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Pontos { get; set; }
        public DateTime Data { get; set; }
    }
}
