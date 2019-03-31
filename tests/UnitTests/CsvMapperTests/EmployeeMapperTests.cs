using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace tests
{
    public class EmployeeMapperTests
    {
        [Fact]
        public void should_map_employee_properties()
        {
            //Given  //when
            var csvMapper = new EmployeeMapper();

            //then
            csvMapper.IndexPropertyMappings.Should().NotBeNullOrEmpty();
            csvMapper.IndexPropertyMappings.Count().Should().Be(3);
            var mappedProperty = csvMapper.IndexPropertyMappings.First();
            mappedProperty.Index.Should().Be(0);
            mappedProperty.AttributeName.Should().Be("Name");
        }
    }
}
