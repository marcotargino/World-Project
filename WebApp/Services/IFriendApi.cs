using System.Threading.Tasks;
using WebApp.Models.Friend;

namespace WebApp.Services
{
    public interface IFriendApi
    {
        Task<PostFriendResult> PostAsync(CreateFriend createFriend);
    }
}