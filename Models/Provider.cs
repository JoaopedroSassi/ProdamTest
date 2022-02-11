using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdamTest.Models
{
    public class Provider
    {
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(70, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(14, ErrorMessage = "Este campo deve ter 11 dígitos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(14, ErrorMessage = "Este campo deve ter 14 dígitos")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(14, ErrorMessage = "Este campo deve ter 9 dígitos")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime HiringDate { get; set; }

        /*[Required(ErrorMessage = "Este campo é obrigatório!")]
        public List<ProviderPhones> Phones { get; set; }*/

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public bool IsPf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
