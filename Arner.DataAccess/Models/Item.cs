using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(30, ErrorMessage = "This name is reach out of length")]
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(50, ErrorMessage = "The location is reach out of length")]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string UpdatedBy { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProviderId { get; set; } 
        public Provider Provider { get; set; }
        public ICollection<Batch> Batchs { get; set; }
        public ICollection<Type> Types { get; set; } = [];
    }
}
