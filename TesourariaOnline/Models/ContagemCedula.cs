using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class ContagemCedula
    {
        public int ContagemCedulaId { get; set; }
        public int ContagemResumoId { get; set; }
        public int CedulaId { get; set; }
        public int Quantidade { get; set; }

        public Cedula Cedula { get; set; }
        public ContagemResumo ContagemResumo { get; set; }
    }
}
