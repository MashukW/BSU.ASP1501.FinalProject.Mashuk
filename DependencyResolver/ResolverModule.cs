using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject.Modules;
using Ninject.Web.Common;
using ORM.EF;
using SocialNetwork.BLL.Interface.Services;

namespace DependencyResolver
{
    public class ResolverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<DbContext>().To<SocialNetworkContext>().InRequestScope();

            Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            Bind<IUserProfileRepository>().To<UserProfileRepository>().InRequestScope();
            Bind<IRoleRepository>().To<RoleRepository>().InRequestScope();
            Bind<IMessageRepository>().To<MessageRepository>().InRequestScope();
            Bind<IFriendRepository>().To<FriendRepository>().InRequestScope();

            Bind<IUserService>().To<UserService>();
            Bind<IUserProfileService>().To<UserProfileService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IMessageService>().To<MessageService>();
            Bind<IFriendService>().To<FriendService>();
            Bind<ISearchService>().To<SearchService>();
        }
    }
}
