using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Friend;

namespace WebApp.Services
{
    public interface IFriendApi
    {
        
        Task<PostFriendResult> PostAsync(CreateFriend createFriend);
        Task<List<ListFriend>> GetAsync();
    }
}