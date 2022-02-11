using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProdamTest.Models
{
    public class Company
    {   
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(2, ErrorMessage = "Este campo deve ter no máxmo 2 caracteres")]
        public string Uf { get; set; }

        /*[Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(90, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]*/
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(14, ErrorMessage = "Este campo deve ter 14 dígitos")]
        public string CNPJ { get; set; }
    }
}
