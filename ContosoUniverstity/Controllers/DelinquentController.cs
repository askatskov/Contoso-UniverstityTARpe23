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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, LastName, FirstMidName, Violation")]Delinquent delinquent)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(delinquent);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.ID == id);
            if (delinquent == null) return NotFound();

            return View(delinquent);
        }


    }
}