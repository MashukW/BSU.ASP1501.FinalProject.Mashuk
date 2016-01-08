using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository.RepositoryCollective
{
    public interface IRepositoryFindBy<TEntity> where TEntity : IEntityDAL
    {
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
