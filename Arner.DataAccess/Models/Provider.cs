using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess.Models
{
    public class Provider
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "This is out of length")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "This is out of length")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string UpdatedBy { get; set; }
        public ICollection<Item> Items { get; }
    }
}
