using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiArcadeScore.Models
{
    public class Estatistica
    {
        [Key]
        public int JogadorId { get; set; }
        public int PartidasJogadas { get; set;} 
        public int MediaPontuacao { get; set; }
        public int MaiorPontuacao { get; set; }
        public int MenorPontuacao { get; set; }
        public int QtdeVezesRecord { get; set; }
        public double TempoJoga { get; set; }
    }
}
