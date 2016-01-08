using BLL.Interface.Entities;
using BLL.Interface.Services.ServiceCollective;

namespace BLL.Interface.Services
{
    public interface IUserService : IBaseService<UserBLL>
    {
        UserBLL GetByEmail(string email);
        bool ToConfirmation(string email);

        string GetEmail(UserBLL user);
        string[] GetUserRoles(string email);
        string GetPassword(UserBLL user);
        bool ChangePassword(string email, string currentPassword, string newPassword);
        bool CreateUserWithRole(UserBLL user, int? roleId);
    }
}
