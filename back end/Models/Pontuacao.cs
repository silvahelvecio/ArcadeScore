using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiArcadeScore.Models
{
    public class Pontuacao
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public DateTime Data { get; set; }
        public int Pontos { get; set; }
    }
}
