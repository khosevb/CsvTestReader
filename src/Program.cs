using System;
using System.IO;
using System.Threading.Tasks;

namespace New
{
    class Program
    {
        static void Main(string[] args)
        {
            //configuration
            AppConfiguration.Configure();

            var csvParser = new CsvParser();
            //read employee category csv file
            var employees = csvParser.Parse<Employee>(@"CsvFiles\Employee.csv");

            //read department category csv file
            var departments = csvParser.Parse<Department>(@"CsvFiles\Department.csv");

            // foreach(var employee in employees)
            // {
            //     Console.WriteLine($"{employee.Name},{employee.Role},{employee.Email}");
            // }

            var employeeContext = new EmployeeContext(AppConfiguration.Configuration);
            //employeeContext.Database.EnsureDeleted();
            //employeeContext.Database.EnsureCreated();
            var unitOfWork = new UnitOfWork(employeeContext);
            
            unitOfWork.EmployeeRepository.AddRange(employees);
            unitOfWork.DepartmentRepository.AddRange(departments);
            unitOfWork.Save();
            

            Console.ReadLine();
        }
    }
}
