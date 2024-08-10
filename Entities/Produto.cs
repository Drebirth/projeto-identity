using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventario.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Dono { get; set; }
    }
}