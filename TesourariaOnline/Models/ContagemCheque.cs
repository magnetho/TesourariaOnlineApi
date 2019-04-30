using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class ContagemCheque
    {
        public int ContagemChequeId { get; set; }
        public int ContageResumoId { get; set; }
        public decimal Valor { get; set; }
        public int TipoCheque { get; set; }
        public string Doador { get; set; }
        public decimal? ValorDoacao { get; set; }

        public ContagemResumo ContageResumo { get; set; }
    }
}
