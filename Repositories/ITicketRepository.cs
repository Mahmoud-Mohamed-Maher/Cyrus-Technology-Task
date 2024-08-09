using Cyrus_Technology_Task.Models;

namespace Cyrus_Technology_Task.Repositories
{
    public interface ITicketRepository
    {
        void Insert(Ticket item);
        List<Ticket> GetAll();

        Ticket Get(string phoneNumber);
        void Save();
    }
}
