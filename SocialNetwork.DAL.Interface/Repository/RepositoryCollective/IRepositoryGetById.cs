using DAL.Interface.DTO;

namespace DAL.Interface.Repository.RepositoryCollective
{
    public interface IRepositoryGetById<TEntity> where TEntity : IEntityDAL
    {
        TEntity GetById(int id);
    }
}
