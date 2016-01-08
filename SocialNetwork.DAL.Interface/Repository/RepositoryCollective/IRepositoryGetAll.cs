using System.Linq;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository.RepositoryCollective
{
    public interface IRepositoryGetAll<TEntity> where TEntity : IEntityDAL
    {
        IQueryable<TEntity> GetAll();
    }
}
