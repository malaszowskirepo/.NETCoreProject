using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;

namespace StudentProject.Controllers
{
    public class HomeController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }

        public HomeController(UserManager<ApplicationUser> UserManager)
        {
            this.UserManager = UserManager;
        }

        public IActionResult Index()
        {
            var users = UserManager.Users;
            return View(users);
        }

    }
}
