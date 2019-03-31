using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace tests
{
    public class CsvMapperTests
    {
        [Fact]
        public void create_map_should_add_mapping()
        {
            //Given
            var csvMapper = new CsvMapper<Employee>();
            //when
            csvMapper.CreateMap(0, e => e.Name);

            //then
            csvMapper.IndexPropertyMappings.Should().NotBeNullOrEmpty();
            var mappedProperty = csvMapper.IndexPropertyMappings.First();
            mappedProperty.Index.Should().Be(0);
            mappedProperty.AttributeName.Should().Be("Name");
        }

        [Fact]
        public void map_should_map_csv_data()
        {
            //Given
            var csvMapper = new CsvMapper<Employee>();
            csvMapper.CreateMap(0, e=> e.Name);
            csvMapper.CreateMap(1, e=> e.Email);
            var csvLines = new List<string>{
                "john,john@mycompany.com",
                "mary,mary@mycompany.com"
            };

            //When
            var output = csvMapper.Map(csvLines);

            //Then
            output.Should().NotBeNullOrEmpty();
            output.Count().Should().Be(2);
            output.First().Name.Should().Be("john");
            output.First().Email.Should().Be("john@mycompany.com");
        }

        [Fact]
        public void map_should_throw_exception_for_invalid_data()
        {
            //Given
            var csvMapper = new CsvMapper<Employee>();
            csvMapper.CreateMap(0, e=> e.Name);
            csvMapper.CreateMap(1, e=> e.Email);
            var csvLines = new List<string>{
                "john",
                "mary,mary@mycompany.com"
            };

            //When
            Action action = () => csvMapper.Map(csvLines);

            //then
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void map_should_throw_missing_mapping_exception_for_not_mapings()
        {
            //Given
            var csvMapper = new CsvMapper<Employee>();
            var csvLines = new List<string>{
                "john",
                "mary,mary@mycompany.com"
            };

            //When
            Action action = () => csvMapper.Map(csvLines);

            //Then
            action.Should().Throw<MissingMappingException>();
        }

    }
}
