using System.ComponentModel.DataAnnotations;

namespace Cyrus_Technology_Task.Models
{
    public class TokenRequestModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
