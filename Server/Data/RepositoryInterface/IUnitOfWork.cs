using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
