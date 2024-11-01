using BulkReversal.Data;
using BulkReversal.Models;
using BulkReversal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BulkReversal.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MakeUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeUser(User user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Priviledge = user.Priviledge
            };
            _context.Add(newUser);
            _context.SaveChanges();
            return View("Login");
        }
        [HttpGet]
        public IActionResult Login() {
            var requests = _context.Requests.ToList();
            var users = _context.Users.ToList();
            var view = new CompositeViewModel
            {
                Requests = requests,
                Users = users
            };
            return View(view);
        }
        [HttpPost]
        public IActionResult Login(User user) {
            var find = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (find == null) {
                return View("MakeUser");
            }
            HttpContext.Session.SetString("SessionId", Guid.NewGuid().ToString());
            HttpContext.Session.SetString("UserId", find.Id.ToString());
            if (find.Priviledge == 1)
            {
                return RedirectToAction("MakeRequest", "Request");
            }
            if (find.Priviledge == 2)
            {
                return RedirectToAction("ViewRequests", "Request");
            }
            return View();
        }
    }
}
