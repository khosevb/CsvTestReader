using System;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace tests
{
    public class CsvParserTests
    {
        private ICsvParser _csvParser;

        [Fact]
        public void parse_should_parse_provided_file()
        {
            //Given
            _csvParser = new CsvParser();
            //when
            var result = _csvParser.Parse<Employee>(@"TestFiles\employee.csv");

            //then
            result.Should().NotBeNullOrEmpty();
            result.Count().Should().Be(4);
        }

        [Fact]
        public void parse_should_throw_missing_mapping_exception_for_no_mapper()
        {
            //Given
            _csvParser = new CsvParser();

            //When
            Action action = () => _csvParser.Parse<InvalidTest>(@"TestFiles\employee.csv");

            //then
            action.Should().Throw<MissingMappingException>();
        }

        [Fact]
        public void parse_should_throw_exception_for_file_not_found()
        {
            //Given
            _csvParser = new CsvParser();

            //When
            Action action = () => _csvParser.Parse<Employee>(@"TestFiles\invalidtest.csv");
            
            //Then
            action.Should().Throw<FileNotFoundException>();
        }

    }
}
