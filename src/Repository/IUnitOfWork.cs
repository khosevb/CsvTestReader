public interface IUnitOfWork
{
    IRepository<Employee> EmployeeRepository { get; }
    IRepository<Department> DepartmentRepository { get; }
    void Save();
}