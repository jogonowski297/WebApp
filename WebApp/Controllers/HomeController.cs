using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContrext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContrext)
        {
            _logger = logger;
            this.applicationDbContrext = applicationDbContrext;
        }

        public async Task<IActionResult> Index()
        {
            var members = await applicationDbContrext.Member.ToListAsync();
            return View(members);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}