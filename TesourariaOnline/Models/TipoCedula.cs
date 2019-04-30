using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class TipoCedula
    {
        public TipoCedula()
        {
            Cedula = new HashSet<Cedula>();
        }

        public int TipoCedulaId { get; set; }
        public string Descricao { get; set; }
        public string Simbolo { get; set; }

        public ICollection<Cedula> Cedula { get; set; }
    }
}
