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
        public int ID { get; set; }
        [MaxLength(30,ErrorMessage = "The name is reach out of length")]
        [MinLength(2, ErrorMessage = "The name is not sufficient")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The username is not valid.")]
        public string Username { get; set; }
        public string Password { get; set; }
        [RegularExpression(@"[\S]+",ErrorMessage = "Email cannot contain space")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Length(10,10, ErrorMessage = "Invalid vietnamese phone number length")]
        [RegularExpression(@"^0[1-9][0-9]+$", ErrorMessage = "Invalid phone vietnamese number format")]
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string? UpdatedBy { get; set; }
        public ICollection<Item>? Items { get; }
        public ICollection<Notification>? Notifications { get; }
    }
}
