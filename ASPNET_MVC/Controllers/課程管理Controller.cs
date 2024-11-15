using ASPNET_MVC.ActionFilters;
using ASPNET_MVC.Models;
using ASPNET_MVC.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ASPNET_MVC.Controllers
{
    //[ServiceFilter<計算每個頁面的實際執行時間Attribute>]
    //[計算每個頁面的實際執行時間]
    [Route("members/[controller]")]
    public class 課程管理Controller : Controller
    {
        private readonly ContosoUniversityContext db;

        public 課程管理Controller(ContosoUniversityContext db)
        {
            this.db = db;            
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var data = db.Courses.Include(p=>p.Department).AsQueryable();
            var paged = await data.ToPagedListAsync(pageNumber, 4);

            return View(paged);
        }

        [HttpGet("New")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("New")]
        public ActionResult Create(CourseCreate data)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(new Course
                {
                    Credits = data.Credits,
                    Title = data.Title,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpGet("info/{slug:maxlength(100)}")]
        public ActionResult Details(string slug)
        {
            //db.Courses.ToList().ForEach(p => p.Slug = p.Title.ToSlug());
            //db.SaveChanges();

            var data = db.Courses.Include(c => c.Department).FirstOrDefault(c => c.Slug == slug);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
    }
}
