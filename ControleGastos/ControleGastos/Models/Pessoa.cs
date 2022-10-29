using System.ComponentModel.DataAnnotations;

namespace ControleGastos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Idade")]
        public int Idade { get; set; }
        [Display(Name = "Data de Registro")]
        public DateTime DataRegistro { get; set; } = DateTime.Now.Date;

        public virtual List<Transacao>? Transacaos { get; set; }
    }
}
