using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Friend;

namespace WebApp.Services
{
    public interface IFriendApi
    {
        object Post(CreateFriend createFriend);
    }

    public class FriendApi : IFriendApi
    {
        public object Post(CreateFriend createFriend)
        {
            throw new NotImplementedException();
        }
    }
}
