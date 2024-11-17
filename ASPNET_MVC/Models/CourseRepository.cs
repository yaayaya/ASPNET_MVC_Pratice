public class CourseRepository : EFRepository<Course>, ICourseRepository
{
    public override IQueryable<Course> All()
    {
        return base.All().Where(c => c.IsDeleted == false).Include(c => c.Department);
    }

    public Course? FindOne (int id)
    {
        return this.All().FirstOrDefault(c => c.CourseId == id);
    }

    public Course? FindOne(string slug)
    {
        return this.All().FirstOrDefault(c => c.Slug == slug);
    }

    public IQueryable<Course> FindAll()
    {
        return this.All();
    }
}

public interface ICourseRepository : IRepository<Course>
{
    Course? FindOne(int id);
    Course? FindOne(string slug);

    IQueryable<Course> FindAll();
}