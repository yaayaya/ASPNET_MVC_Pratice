namespace ASPNET_MVC.Controllers;

//[ServiceFilter<計算每個頁面的實際執行時間Attribute>]
//[計算每個頁面的實際執行時間]
[Route("members/[controller]")]
public class 課程管理Controller : Controller
{
    private readonly ICourseRepository courseRepo;
    private readonly IDepartmentRespository departmentRepo;
    private readonly IUnitOfWork uow;

    public 課程管理Controller(ICourseRepository courseRepo , IDepartmentRespository departmentRepo,  IUnitOfWork uow)
    {
        this.courseRepo = courseRepo;
        this.departmentRepo = departmentRepo;
        this.uow = uow;
        this.courseRepo.UnitOfWork = uow;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        var data = courseRepo.FindAll();
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
            courseRepo.Add(new Course
            {
                Credits = data.Credits,
                Title = data.Title,
            });

            courseRepo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        return View(data);
    }

    [HttpGet("info/{slug:maxlength(100)}")]
    public ActionResult Details(string slug)
    {
        //courseRepo.Courses.ToList().ForEach(p => p.Slug = p.Title.ToSlug());
        //courseRepo.SaveChanges();

        var data = courseRepo.FindOne(slug);

        if (data == null)
        {
            return NotFound();
        }

        return View(data);
    }
}
