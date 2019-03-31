using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly EmployeeContext _dbContext;

    public Repository(EmployeeContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> List()
    {
        return _dbContext.Set<T>().AsEnumerable();
    }

    public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>()
               .Where(predicate)
               .AsEnumerable();
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void Edit(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().AddRange(entities);
    }
}