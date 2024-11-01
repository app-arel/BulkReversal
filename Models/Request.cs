namespace BulkReversal.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid userId { get; set; }
        public bool Approved { get; set; } = false;
    }
}
