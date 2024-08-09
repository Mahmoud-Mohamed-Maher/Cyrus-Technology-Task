using Cyrus_Technology_Task.Models;

namespace Cyrus_Technology_Task.Repositories
{
    public interface IAppUserRepository
    {
        List<AppUser> GetAll();

        AppUser Get(string phoneNumber);
        void Save();
    }
}
