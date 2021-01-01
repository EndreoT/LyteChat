using System.Threading.Tasks;

namespace LyteChat.Server.Data.RepositoryInterface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
