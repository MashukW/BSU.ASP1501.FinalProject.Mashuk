using DAL.Interface.DTO;

namespace DAL.Interface.Repository.RepositoryCollective
{
    public interface IRepository<TEntity> : IRepositoryCRUD<TEntity>, IRepositoryGetById<TEntity>,
        IRepositoryGetAll<TEntity>, IRepositoryFindBy<TEntity> where TEntity : IEntityDAL
    {

    }
}
