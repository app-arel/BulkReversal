namespace BulkReversal.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string SenderAccount { get; set; }
        public string ReceiverAccount { get; set;}
        public decimal Amount { get; set; }
    }
}
