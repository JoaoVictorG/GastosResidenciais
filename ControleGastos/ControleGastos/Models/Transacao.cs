using System.ComponentModel.DataAnnotations;

namespace ControleGastos.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        [Display(Name = "Data de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRegistro { get; set; } = DateTime.Now.Date;

        public Pessoa? Pessoa { get; set; }
    }
}
