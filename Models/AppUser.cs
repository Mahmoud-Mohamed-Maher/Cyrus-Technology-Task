using System.ComponentModel.DataAnnotations;

namespace Cyrus_Technology_Task.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
