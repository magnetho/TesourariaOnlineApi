using System;
using System.Collections.Generic;

namespace TesourariaOnline.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
