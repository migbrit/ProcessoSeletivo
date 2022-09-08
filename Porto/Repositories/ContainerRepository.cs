using Porto.Context;
using Porto.Models;
using Porto.Repositories.Interfaces;

namespace Porto.Repositories
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly AppDbContext _context;
        public ContainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Container> Containers => _context.Containers;

        public void AdicionarContainer(Container container)
        {
            _context.Containers.Add(container);
            _context.SaveChanges();
        }

        public void RemoverContainer(Container container)
        {
            _context.Containers.Remove(container);
            _context.SaveChanges();
        }

        public Container EncontrarContainer(int id)
        {
            var container = _context.Containers.Find(id);
            return container;
        }

        public void AtualizarContainer(Container container)
        {
            _context.Containers.Update(container);
            _context.SaveChanges();
        }
    }
}
