using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulkReversal.Models
{
    [Index("Email", IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Priviledge { get; set; }

    }
}
