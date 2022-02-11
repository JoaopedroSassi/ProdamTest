using System.ComponentModel.DataAnnotations;

namespace ProdamTest.Models
{
    public class ProviderPhones
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string PhoneNumber { get; set;}
    }
}
