using Cyrus_Technology_Task.Models;
using static Cyrus_Technology_Task.Repositories.TicketRepository;

namespace Cyrus_Technology_Task.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        protected readonly Context Context;

        public TicketRepository(Context _context)
        {
            Context = _context;
        }
        public Ticket Get(string phoneNumber)
        {
            return Context.Tickets.FirstOrDefault(t=>t.UserPhoneNumber==phoneNumber);
        }

        public List<Ticket> GetAll()
        {
            return Context.Tickets.OrderByDescending(t => t.TicketNumber).ToList();
        }

        public void Insert(Ticket item)
        {
            Context.Add(item);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
