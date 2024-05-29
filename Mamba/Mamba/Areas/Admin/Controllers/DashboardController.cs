using Mamba.DAL;
using Mamba.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {List<Member> members =_context.Members.ToList();
            return View(members);
        }
       
    }
}
