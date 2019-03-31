using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace tests
{
    public class DepartmentMapperTests
    {
        [Fact]
        public void should_map_department_properties()
        {
            //Given  //when
            var csvMapper = new DepartmentMapper();

            //then
            csvMapper.IndexPropertyMappings.Should().NotBeNullOrEmpty();
            csvMapper.IndexPropertyMappings.Count().Should().Be(2);
            var mappedProperty = csvMapper.IndexPropertyMappings.First();
            mappedProperty.Index.Should().Be(0);
            mappedProperty.AttributeName.Should().Be("Name");
        }
    }
}
