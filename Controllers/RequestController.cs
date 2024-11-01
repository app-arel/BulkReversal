using BulkReversal.Data;
using BulkReversal.Models;
using BulkReversal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BulkReversal.Controllers
{
    public class RequestController : Controller
    {
        private readonly DataContext _context;
        public RequestController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MakeRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeRequest(RequestViewModel request)
        {
                var userId = Guid.Parse(HttpContext.Session.GetString("UserId"));
                var user = _context.Users.FirstOrDefault(x => x.Id == userId);
                var c = request.TransactionId;
                for (int i = 0; i <= request.TransactionId.Count - 1; i++)
                {
                    Request newRequest = new Request
                    {
                        TransactionId = request.TransactionId[i],
                        userId = userId
                    };
                    _context.Requests.Add(newRequest);
                    _context.SaveChanges();
                }
            
                return View();
        }
        [HttpGet]
        public IActionResult ViewRequests() { 
            var requests = _context.Requests.ToList();
            return View(requests);
        }
        [HttpGet]
        public IActionResult ReviewRequest(Guid Id) {
            var request = _context.Requests.FirstOrDefault(x => x.Id == Id);
            HttpContext.Session.SetString("RequestId", Id.ToString());
            return View(request);
        }
        [HttpPost]
        public IActionResult ApproveRequest(Request request) {
            var Id = Guid.Parse(HttpContext.Session.GetString("RequestId"));
            var get = _context.Requests.FirstOrDefault(x=> x.Id == Id);
            Console.WriteLine(Id);
            var check = request.Approved;
            if(check == true)
            {
                Console.WriteLine("Trueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                var transaction = _context.Transactions.FirstOrDefault(x => x.Id == get.TransactionId);
                Console.WriteLine(get.TransactionId);
                var account = _context.Accounts.FirstOrDefault(x => x.AccountNumber == transaction.SenderAccount);
                account.Balance = account.Balance + transaction.Amount;
                Console.WriteLine(get.TransactionId);
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Falseeeeeeeeeeeeeeeeeeeeeeeeeeee");
            }
            _context.SaveChanges();
            return View("MakeRequest");
        }
    }
}
