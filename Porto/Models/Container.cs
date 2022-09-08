using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porto.Models
{
    [Table("Containers")]
    public class Container
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatório")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Numero do container é obrigatório")]
        [Display(Name = "Numero do container")]
        public string NumeroContainer { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatório")]
        public string Categoria { get; set; }
    }
}
