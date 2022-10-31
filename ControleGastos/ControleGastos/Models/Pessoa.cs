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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRegistro { get; set; } = DateTime.Now.Date;

        public ICollection<Transacao>? Transacao { get; set; }
    }
}
