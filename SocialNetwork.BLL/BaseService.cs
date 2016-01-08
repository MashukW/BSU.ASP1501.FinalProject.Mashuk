using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Services.ServiceCollective;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using DAL.Interface.Repository.RepositoryCollective;
using static SocialNetwork.Helper.HelperConvert;

namespace BLL
{
    public abstract class BaseService<TEntityBLL, TEntityDAL> : IBaseService<TEntityBLL>
        where TEntityBLL : IEntityBLL where TEntityDAL : IEntityDAL
    {
        protected readonly IUnitOfWork workRepository;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            workRepository = unitOfWork;
        }

        #region Implementation of interface methods --> IBaseService

        public void Add(TEntityBLL entity)
        {
            if (entity == null)
                throw new InvalidOperationException("Add entity is null");
            
            TEntityDAL entityForAdd = EntityConvert<TEntityBLL, TEntityDAL>(entity);

            if (entityForAdd == null)
                return;

            var success = GetRepository().Add(entityForAdd);

            if (!success)
                return;

            workRepository.Commit();
        }

        public IEnumerable<TEntityBLL> FindBy(Expression<Func<TEntityBLL, bool>> predicate)
        {
            if (predicate == null)
                throw new InvalidOperationException("Predicate is null");

            var entities = GetRepository().FindBy(
                PredicateConvert<TEntityBLL, TEntityDAL>(predicate));
            
            return EntityConvert<TEntityDAL, TEntityBLL>(entities);
        }

        public IEnumerable<TEntityBLL> GetAll()
        {
            return EntityConvert<TEntityDAL, TEntityBLL>(GetRepository().GetAll());
        }

        public TEntityBLL GetById(int id)
        {
            if (id < 0)
                return default(TEntityBLL);
            
            return EntityConvert<TEntityDAL, TEntityBLL>(GetRepository().GetById(id));
        }

        public void Remove(int id)
        {
            if (id < 0)
                throw new InvalidOperationException(nameof(id));

            var success = GetRepository().Remove(id);

            if (!success)
                return;

            workRepository.Commit();
        }
               
        public void Remove(TEntityBLL entity)
        {
            if (entity == null)
                throw new InvalidOperationException(nameof(entity));

            Remove(entity.Id);
        }
               
        public void Update(TEntityBLL entity)
        {
            if (entity == null)
                throw new InvalidOperationException(nameof(entity));

            var success = GetRepository().Update(EntityConvert<TEntityBLL, TEntityDAL>(entity));

            if (!success)
                return;

            workRepository.Commit();
        }

        #endregion

        protected abstract IRepository<TEntityDAL> GetRepository();
    }
}
