using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;

namespace BLL.Interface.Services.ServiceCollective
{
    public interface IBaseService<TEntityBLL> where TEntityBLL : IEntityBLL
    {
        IEnumerable<TEntityBLL> FindBy(Expression<Func<TEntityBLL, bool>> predicate);
        IEnumerable<TEntityBLL> GetAll();
        TEntityBLL GetById(int id);
        void Add(TEntityBLL entity);
        void Remove(TEntityBLL entity);
        void Remove(int id);
        void Update(TEntityBLL entity);
    }
}
