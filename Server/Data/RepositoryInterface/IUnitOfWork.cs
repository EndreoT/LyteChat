using System.Threading.Tasks;

namespace LearnBlazor.Data.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
