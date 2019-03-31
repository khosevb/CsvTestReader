# CsvTestReader
## Tools/Technologies used
  - dotner core 2.2
  - EF Core
  - xUnit
  - Fluent assertions
  - Microsoft dependency injection extension

## Csv test parser has following components
   ### Csv mapper 
   This is base class to create entity specific mapper. This class will be overriden to define entiity specific csv to        property  mapping using create map method. Create map method maintains this mapping in a collection to be used later for actual mapping
   e.g.
   ```
   public class EmployeeMapper : CsvMapper<Employee>
  {
      public EmployeeMapper() : base()
      {
          CreateMap(0, x => x.Name);
          CreateMap(1, x => x.Role);
          CreateMap(2, x => x.Email);
      }
  }
  ```
   This class also has an Map method which acceps data from file and maps it to entity using mapping created earlier.
   
   ### Csv parser 
   Csv Parser parses csv file and uses csv mappper to map it to entity
   
   ### Repository
   Repository has sample implementation for storing data to sql server. Here I have used azure sql storage.
   
