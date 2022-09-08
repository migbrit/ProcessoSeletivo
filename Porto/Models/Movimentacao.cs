using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Porto.Models
{
    [Table("Movimentacoes")]
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo da movimentação é obrigatória")]
        [Display(Name = "Tipo da movimentação")]
        public string TipoMovimentacao { get; set; }

        [Required(ErrorMessage = "Data de início é obrigatória")]
        [Display(Name = "Data de início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Data de fim é obrigatória")]
        [Display(Name = "Data de fim")]
        public DateTime DataFim { get; set; }
    }
}
