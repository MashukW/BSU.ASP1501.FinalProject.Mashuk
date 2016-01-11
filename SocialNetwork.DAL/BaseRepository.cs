using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DAL.Interface.DTO;
using DAL.Interface.Repository.RepositoryCollective;
using ORM.Entities;
using static SocialNetwork.Helper.HelperConvert;

namespace DAL
{
    public abstract class BaseRepository<TEntityDAL, TEntityDB> : IRepository<TEntityDAL>
        where TEntityDAL : IEntityDAL where TEntityDB : class, IEntityDB
    {
        protected readonly DbContext context;

        protected BaseRepository(DbContext context)
        {
            if (context == null)
                throw new NullReferenceException(nameof(context));
            this.context = context;
        }

        #region Implementation of interface methods --> IRepository

        public virtual bool Add(TEntityDAL entity)
        {
            if (entity == null)
                return false;
            
            TEntityDB entityForAdd = EntityConvert<TEntityDAL, TEntityDB>(entity);

            if (entityForAdd == null)
                return false;

            context.Set<TEntityDB>().Add(entityForAdd);
            return true;
        }

        public virtual bool Update(TEntityDAL entity)
        {
            if (entity == null)
                return false;

            TEntityDB entityToUpdate = GetEntity(entity.Id);

            if (entityToUpdate == null)
                return false;

            PropertyInfo[] propertiesToUpdate = typeof(TEntityDB).GetProperties();
            PropertyInfo[] newValuesOfProperties = typeof (TEntityDAL).GetProperties();

            foreach (var prop in propertiesToUpdate)
            {
                foreach (var newValue in newValuesOfProperties)
                {
                    if (prop.Name != newValue.Name || !prop.CanWrite)
                        continue;

                    prop.SetValue(entityToUpdate, newValue.GetValue(entity));
                    break;
                }
            }

            context.Set<TEntityDB>().AddOrUpdate(entityToUpdate);
            return true;
        }

        public IQueryable<TEntityDAL> GetAll()
        {
            return context.Set<TEntityDB>().Select(GetConverter());  //EntityConvert<TEntityDB, TEntityDAL>();
        }

        public TEntityDAL GetById(int id)
        {
            TEntityDB entity = GetEntity(id);

            if (entity == null)
                return default(TEntityDAL);

            return EntityConvert<TEntityDB, TEntityDAL>(entity);
        }

        public bool Remove(TEntityDAL entity)
        {
            return entity != null && Remove(entity.Id);
        }
        public virtual bool Remove(int id)
        {
            if (id < 0)
                return false;

            TEntityDB entityForRemove = GetEntity(id);

            if (entityForRemove == null)
                return false;

            context.Set<TEntityDB>().Remove(entityForRemove);
            return true;
        }

        public IEnumerable<TEntityDAL> FindBy(Expression<Func<TEntityDAL, bool>> predicate)
        {
            if (predicate == null)
                return null;

            IEnumerable<TEntityDB> entities = context.Set<TEntityDB>().Where(
                PredicateConvert<TEntityDAL, TEntityDB>(predicate));

            return EntityConvert<TEntityDB, TEntityDAL>(entities);
        }

        #endregion

        protected TEntityDB GetEntity(int? id)
        {
            return context.Set<TEntityDB>().FirstOrDefault(p => p.Id == id);
        }
        protected abstract Expression<Func<TEntityDB, TEntityDAL>> GetConverter();
    }
}
