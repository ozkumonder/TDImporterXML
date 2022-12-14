using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TDImporterXML.Core.Entities;

namespace TDImporterXML.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        T Update(T entity);

        bool Delete(T entity);
    }
}
