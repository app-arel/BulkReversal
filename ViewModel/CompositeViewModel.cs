using BulkReversal.Models;

namespace BulkReversal.ViewModel
{
    public class CompositeViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public Request Request { get; set; }
        public List<Request> Requests { get; set; }
    }
}
