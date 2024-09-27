using ContosoUniverstity.Data;
using ContosoUniverstity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniverstity.Controllers
{
    public class DelinquetController : Controller
    {
        public readonly SchoolContext _context;

        public DelinquetController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var delinquents = await _context.Delinquents.ToListAsync();
            return View(delinquents);
        }


    }
}