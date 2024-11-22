using ContosoUniverstity.Data;
using ContosoUniverstity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniverstity.Controllers
{
    public class DelinquentController : Controller
    {
        public readonly SchoolContext _context;

        public DelinquentController(SchoolContext context)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delinquent = await _context.Delinquents.FindAsync(id);
            if (delinquent != null)

            {
                return NotFound();
            }
            return View(delinquent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, Delinquent delinquent)
        {
            if (id != delinquent.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delinquent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelinquentExists(delinquent.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(delinquent);
        }
        private bool DelinquentExists(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents
                .FirstOrDefaultAsync(m => m.ID == id);

            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);


        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delinquent = await _context.Delinquents.FindAsync(id);

            _context.Delinquents.Remove(delinquent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}