public class EmployeeMapper : CsvMapper<Employee>
{
    public EmployeeMapper() : base()
    {
        CreateMap(0, x => x.Name);
        CreateMap(1, x => x.Role);
        CreateMap(2, x => x.Email);
    }
}