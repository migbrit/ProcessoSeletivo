using Porto.Models;

namespace Porto.Repositories.Interfaces
{
    public interface IMovimentacaoRepository
    {
        IEnumerable<Movimentacao> Movimentacoes { get; }
        public void AdicionarMovimentacao(Movimentacao movimentacao);
        public void RemoverMovimentacao(Movimentacao movimentacao);
        public Movimentacao EncontrarMovimentacao(int id);

        public void AtualizarMovimentacao(Movimentacao movimentacao);
    }
}
