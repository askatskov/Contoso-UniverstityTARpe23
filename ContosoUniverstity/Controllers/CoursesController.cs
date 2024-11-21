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
		[HttpGet]
		public async Task<IActionResult> CreateEdit(int? id)
		{
			if (id == null)
			{
				ViewBag.Title = "Create";
				ViewBag.Description = "Create a new course";
				return View();
			}
			var course = await _context.Courses.FindAsync(id);
			if (course == null)
			{
				return NotFound();
			}
			ViewBag.Title = "Edit";
			ViewBag.Description = "Edit course details";
			return View(course);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> CreateEdit(Course course)
		{
			if (ModelState.IsValid)
			{
				if (course.CourseID == 0)
				{
					int biggestCourseID = await _context.Courses.AnyAsync()
						? await _context.Courses.MaxAsync(c => c.CourseID)
						: 0;

					course.CourseID = biggestCourseID + 1;
					_context.Add(course);
					await _context.SaveChangesAsync();
				}
				else
				{
					_context.Update(course);
					await _context.SaveChangesAsync();
				}
				return RedirectToAction("Index");
			}

			ViewBag.Title = course.CourseID == 0 ? "Create" : "Edit";
			ViewBag.Description = course.CourseID == 0 ? "Create a new course" : "Edit course details";
			return View(course);
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
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

			ViewBag.Title = "Delete Course";
			return View("DetailsDelete", course);

		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> DeleteConfirmed(int CourseID)
		{
			var course = await _context.Courses.FindAsync(CourseID);
			if (course == null)
			{
				return NotFound();
			}

			_context.Courses.Remove(course);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Clone(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var course = await _context.Courses.FindAsync(id);
			if (course == null)
			{
				return NotFound();
			}

			var clonedCourse = new Course
			{
				Title = course.Title,
				Credits = course.Credits
			};
			_context.Add(clonedCourse);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
	}
}


