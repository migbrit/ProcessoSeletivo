using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Porto.Context;
using Porto.Models;
using Porto.Repositories.Interfaces;

namespace Porto.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoController(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public ActionResult Index()
        {
            var movimentacoes = _movimentacaoRepository.Movimentacoes;
            return View(movimentacoes);
        }


        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _movimentacaoRepository.Movimentacoes.FirstOrDefault(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

 
        public ActionResult Create()
        {
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                _movimentacaoRepository.AdicionarMovimentacao(movimentacao);
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacao);
        }

  
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _movimentacaoRepository.EncontrarMovimentacao(id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,TipoMovimentacao,DataInicio,DataFim")] Movimentacao movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movimentacaoRepository.AtualizarMovimentacao(movimentacao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_movimentacaoRepository.EncontrarMovimentacao(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(movimentacao);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = _movimentacaoRepository.Movimentacoes.FirstOrDefault(m => m.Id == id);

            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Movimentacao movimentacao)
        {
            _movimentacaoRepository.RemoverMovimentacao(movimentacao);
            return RedirectToAction(nameof(Index));
        }
    }
}
