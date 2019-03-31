using System;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly EmployeeContext _employeeContext;
    private IRepository<Employee> _employeeRepository;
    private IRepository<Department> _departmentRepository;
    public UnitOfWork(EmployeeContext employeeContext)
    {
        _employeeContext = employeeContext;
    }

    public IRepository<Employee> EmployeeRepository
    {
        get
        {
            return _employeeRepository = _employeeRepository ?? new Repository<Employee>(_employeeContext);
        }
    }

    public IRepository<Department> DepartmentRepository
    {
        get
        {
            return _departmentRepository = _departmentRepository ?? new Repository<Department>(_employeeContext);
        }
    }

    public void Save()
    {
        _employeeContext.SaveChanges();
    }

    private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _employeeContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
}