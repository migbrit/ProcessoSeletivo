using Porto.Context;
using Porto.Models;

namespace Porto.Repositories.Interfaces
{
    public interface IContainerRepository
    {
        IEnumerable<Container> Containers { get; }
        public void AdicionarContainer(Container container);
        public void RemoverContainer(Container container);
        public Container EncontrarContainer(int id);

        public void AtualizarContainer(Container container);
    }
}
