using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class Movimento
    {
        public Movimento()
        {
            ContagemResumo = new HashSet<ContagemResumo>();
        }

        public int MovimentoId { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public string Usuario { get; set; }
        public DateTime DataAlteracao { get; set; }

        public ICollection<ContagemResumo> ContagemResumo { get; set; }
    }
}
