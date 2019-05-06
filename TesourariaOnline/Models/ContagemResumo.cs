using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class ContagemResumo
    {
        public ContagemResumo()
        {
            ContagemCedula = new HashSet<ContagemCedula>();
            ContagemCheque = new HashSet<ContagemCheque>();
        }

        public int ContagemResumoId { get; set; }
        public int? MovimentoId { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorSistema { get; set; }
        public DateTime? Data { get; set; }
        public int? Status { get; set; }
        public string Usuario { get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual Movimento Movimento { get; set; }
        public virtual ICollection<ContagemCedula> ContagemCedula { get; set; }
        public virtual ICollection<ContagemCheque> ContagemCheque { get; set; }
    }
}
