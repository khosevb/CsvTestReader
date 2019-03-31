using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class EmployeeContext : DbContext
{
    private readonly IConfiguration _configuration;
    public EmployeeContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = _configuration.GetConnectionString("EmployeeDatabase");
        optionsBuilder.UseSqlServer(connection);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>();
        modelBuilder.Entity<Department>();
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}