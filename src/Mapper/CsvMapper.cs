using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public class CsvMapper<TEntity> where TEntity:class,new()
{
    public List<IndexPropertyMapping> IndexPropertyMappings { get; set; }
    public CsvMapper()
    {
        IndexPropertyMappings = new List<IndexPropertyMapping>();
    }
    public void CreateMap<TProperty>(int index, Expression<Func<TEntity, TProperty>> property)
    {
        IndexPropertyMappings.Add(new IndexPropertyMapping{
            Index = index,
            AttributeName = ((MemberExpression)property.Body).Member.Name
        });
    }

    public IEnumerable<TEntity> Map(IEnumerable<string> csvLines)
    {
        var mappedCollection = new List<TEntity>();
        if(IndexPropertyMappings.Count > 0)
        {
            foreach(var line in csvLines)
            {
                var details = line.Split(",");
                var instance = new TEntity();
                foreach(var mapping in IndexPropertyMappings)
                {
                    SetValue(instance, mapping.AttributeName, details[mapping.Index]);
                }
                mappedCollection.Add(instance);
            }
        }
        else
        {
            throw new MissingMappingException();
        }

        return mappedCollection;
    } 
    private static void SetValue<T>(T inputObject, string propertyName, object propertyVal)
    {
        Type type = inputObject.GetType();
        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(propertyName);
        Type propertyType = propertyInfo.PropertyType;

        var targetType = IsNullableType(propertyType) ? Nullable.GetUnderlyingType(propertyType) : propertyType;

        propertyVal = Convert.ChangeType(propertyVal, targetType);
        propertyInfo.SetValue(inputObject, propertyVal, null);

    }
    private static bool IsNullableType(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
    }
}