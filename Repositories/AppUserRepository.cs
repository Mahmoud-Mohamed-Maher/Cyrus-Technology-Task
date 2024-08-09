using Cyrus_Technology_Task.Models;

namespace Cyrus_Technology_Task.Repositories
{
    public class AppUserRepository :IAppUserRepository
    {
        protected readonly Context Context;

        public AppUserRepository(Context _context)
        {
            Context = _context;
        }
        public AppUser Get(string phoneNumber)
        {
            return Context.AppUsers.FirstOrDefault(u=>u.MobileNumber==phoneNumber);
        }

        public List<AppUser> GetAll()
        {
            return Context.AppUsers.ToList();
        }


        public void Save()
        {
            Context.SaveChanges();
        }

        
    }
}
