using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using inventario.Models;

namespace inventario.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nenhum dos campos informado pode está vazio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição não pode ser vazia!")]
        public string Descricao {get; set;}

        [Required(ErrorMessage = "Valor vazio nao!")]
        public int Quantidade { get; set;}
        public string Dono { get; set; }

        
    }
}