//using Mamba.Models;
using Mamba.DAL;
using Mamba.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mamba.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
             List<Member> members=_context.Members.ToList();
            return View(members);
        }

        
    }
}
