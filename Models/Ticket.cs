using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrus_Technology_Task.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        
        public int TicketNumber { get; set; }

        // I Didn't Get What you want exactly so i made it as a string 
        // but i can upload img and i did it in a deferent project with IFormFile 
        public string TicketImage { get; set; } 

        public string UserPhoneNumber { get; set; }


        [ForeignKey("AppUser")]

        public int UserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
