using System.Collections.Generic;

public interface ICsvParser
{
    IEnumerable<T> Parse<T>(string fileName) where T:class, new();
}