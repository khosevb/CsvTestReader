using System.Collections.Generic;
using System.IO;

public class CsvParser : ICsvParser
{
    public IEnumerable<T> Parse<T>(string fileName) where T:class, new()
    {
        var lines = File.ReadLines(fileName);
        CsvMapper<T> mapper = null;
        if(typeof(T) == typeof(Employee))
            mapper = new EmployeeMapper() as CsvMapper<T>;
        if(typeof(T) == typeof(Department))
            mapper = new DepartmentMapper() as CsvMapper<T>;
        
        if(mapper == null)
            throw new MissingMappingException();
        
        return mapper.Map(lines);

    }
}
