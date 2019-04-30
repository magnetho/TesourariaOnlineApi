using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class Cedula
    {
        public Cedula()
        {
            ContagemCedula = new HashSet<ContagemCedula>();
        }

        public int CedulaId { get; set; }
        public int TipoCedulaId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public TipoCedula TipoCedula { get; set; }
        public ICollection<ContagemCedula> ContagemCedula { get; set; }
    }
}
