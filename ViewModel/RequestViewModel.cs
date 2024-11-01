using BulkReversal.Models;

namespace BulkReversal.ViewModel
{
    public class RequestViewModel
    {
        public Guid Id { get; set; }
        public List<Guid> TransactionId { get; set; } = new List<Guid>();
        public User user { get; set; }
        public bool Approved { get; set; } = false;
    }
}
