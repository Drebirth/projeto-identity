using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inventario.Models;

    public class RegisterViewModel
    {
       public string? UserName {get; set;}

        [Required]
        [DataType(DataType.Password)]
       public string? Password {get; set;}
    }
