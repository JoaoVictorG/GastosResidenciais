namespace ControleGastos.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now.Date;

        public virtual List<Transacao>? Transacaos { get; set; }
    }
}
