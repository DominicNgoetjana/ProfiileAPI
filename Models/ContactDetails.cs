using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Models
{
    public class ContactDetails : User
    {
        [MaxLength(15)]
        public string MobileNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
    }
}