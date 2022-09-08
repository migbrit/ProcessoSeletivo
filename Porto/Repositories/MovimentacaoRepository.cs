using Porto.Context;
using Porto.Models;
using Porto.Repositories.Interfaces;

namespace Porto.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;
        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movimentacao> Movimentacoes => _context.Movimentacoes;

        public void AdicionarMovimentacao(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            _context.SaveChanges();
        }

        public void RemoverMovimentacao(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Remove(movimentacao);
            _context.SaveChanges();
        }

        public Movimentacao EncontrarMovimentacao(int id)
        {
            var movimentacao = _context.Movimentacoes.Find(id);
            return movimentacao;
        }

        public void AtualizarMovimentacao(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Update(movimentacao);
            _context.SaveChanges();
        }
    }
}
