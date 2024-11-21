using ContosoUniverstity.Data;
using Microsoft.AspNetCore.Mvc;
using ContosoUniverstity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniverstity.Controllers
{
	public class CoursesController : Controller
	{
		private readonly SchoolContext _context;

		public CoursesController(SchoolContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Courses.ToListAsync());
		}
		[HttpGet, ActionName("DetailsDelete")]
		public async Task<IActionResult> Details(int? id, string name)
		{
			if (id == null)
			{
				return NotFound();
			}
			var course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);
			if (course == null)
			{
				return NotFound();
			}

			if (name != "Details" && name != "Delete")
			{
				return NotFound();
			}

			ViewBag.Title = name == "Details" ? "Course Details" : "Delete Course";
			return View(course);
		}
	}
}


