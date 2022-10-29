using System.ComponentModel.DataAnnotations;

namespace ControleGastos.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}
