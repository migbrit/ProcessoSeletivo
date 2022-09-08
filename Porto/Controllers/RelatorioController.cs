using Microsoft.AspNetCore.Mvc;
using Porto.Repositories.Interfaces;

namespace Porto.Controllers
{
    public class RelatorioController : Controller
    {
        //d
        private readonly IContainerRepository _containerRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        public RelatorioController(IContainerRepository containerRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            _containerRepository = containerRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }
        public IActionResult Index()
        {
            ViewData["Containers"] = _containerRepository.Containers;
            ViewData["Movimentacoes"] = _movimentacaoRepository.Movimentacoes;
            return View();
        }
    }
}
