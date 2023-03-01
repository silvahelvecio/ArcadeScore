using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiArcadeScore.Models
{
    public class Jogadores
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
