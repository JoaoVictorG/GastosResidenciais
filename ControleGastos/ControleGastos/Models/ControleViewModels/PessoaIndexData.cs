namespace ControleGastos.Models.ControleViewModels
{
    public class PessoaIndexData
    {
        public IEnumerable<Pessoa> Pessoas { get; set; }
        public IEnumerable<Transacao> Transacaos { get; set; }
    }
}
