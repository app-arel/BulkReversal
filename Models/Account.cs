using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulkReversal.Models
{
    [Index ("AccountNumber", IsUnique = true)]
    public class Account
    {
        public Guid Id { get; set; }
        [StringLength (50)]
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
    }
}
