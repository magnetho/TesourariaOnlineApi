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

        public virtual Cedula Cedula { get; set; }
        public virtual ContagemResumo ContagemResumo { get; set; }
    }
}
