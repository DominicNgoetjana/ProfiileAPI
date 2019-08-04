using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        [MaxLength(13)]
        public string IDNumber { get; set; }
        [MaxLength(15)]
        public string PassportNumber { get; set; }
    }
}