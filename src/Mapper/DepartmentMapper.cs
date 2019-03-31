public class DepartmentMapper : CsvMapper<Department>
{
    public DepartmentMapper() : base()
    {
        CreateMap(0, x => x.Name);
        CreateMap(1, x => x.Division);
    }
}