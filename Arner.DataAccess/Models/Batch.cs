using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arner.DataAccess.Models
{
    public enum ItemStatus
    {
        Available,
        Ordering,
        SoldOut,
        NearOutOfDate
    }
    public class Batch
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ImportDate { get; set; }
        public ItemStatus Status { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(100, ErrorMessage = "This is out of length")]
        public string UpdatedBy { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
