using System.Collections.Generic;
using BLL.Interface.Entities;

namespace SocialNetwork.BLL.Interface.Services
{
    public interface ISearchService
    {
        IEnumerable<UserBLL> Search(string criterion);
    }
}
