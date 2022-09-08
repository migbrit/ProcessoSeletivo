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
    public class ContainerController : Controller
    {
        private readonly IContainerRepository _containerRepository;
        public ContainerController(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }


        public ActionResult Index()
        {
            var containers = _containerRepository.Containers;
            return View(containers);
        }

        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var container = _containerRepository.Containers.FirstOrDefault(c => c.Id == id);

            if(container == null)
            {
                return NotFound();
            }

            return View(container);
        }


        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Container container)
        {
            if (ModelState.IsValid)
            {
                _containerRepository.AdicionarContainer(container);
                return RedirectToAction(nameof(Index));
            }
            return View(container);
        }

      
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var container = _containerRepository.EncontrarContainer(id);
            if(container == null)
            {
                return NotFound();
            }

            return View(container);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Cliente,NumeroContainer,Tipo,Status,Categoria")] Container container)
        {
            if(id != container.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _containerRepository.AtualizarContainer(container);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(_containerRepository.EncontrarContainer(id) == null)
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
            return View(container);
        }

      
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var container = _containerRepository.Containers.FirstOrDefault(c => c.Id == id);

            if(container == null)
            {
                return NotFound();
            }

            return View(container);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Container container)
        {
            _containerRepository.RemoverContainer(container);
            return RedirectToAction(nameof(Index));
        }

   
    }
}
