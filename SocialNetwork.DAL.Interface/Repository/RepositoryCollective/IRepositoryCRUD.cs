using DAL.Interface.DTO;

namespace DAL.Interface.Repository.RepositoryCollective
{
    public interface IRepositoryCRUD<TEntity> where TEntity : IEntityDAL
    {
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        bool Remove(int id);
    }
}
