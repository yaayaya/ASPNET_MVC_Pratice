public class DepartmentRespository : EFRepository<Department>, IDepartmentRespository
{
    public override IQueryable<Department> All()
    {
        return base.All();
    }

    public Department? FindOne (int id)
    {
        return this.All().FirstOrDefault(c => c.DepartmentId == id);
    }

    public IQueryable<Department> FindAll()
    {
        return this.All();
    }
}

public interface IDepartmentRespository : IRepository<Department>
{
    Department? FindOne(int id);

    IQueryable<Department> FindAll();
}