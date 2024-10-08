using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }
        [MaxLength(30,ErrorMessage = "The name is reach out of length")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "The Name field should contain only letters and spaces.")]
        public string Username { get; set; }
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [MaxLength(15, ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string? UpdatedBy { get; set; }
        public ICollection<Item> Items { get; }
        public ICollection<Notification> Notifications { get; }
    }
}
