using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Friend;

namespace WebApp.Services
{
    public interface IFriendApi
    {
        Task PostAsync(CreateFriend createFriend);
    }

    public class FriendApi : IFriendApi
    {
        public async Task PostAsync(CreateFriend createFriend)
        {
            var createFriendJson = JsonConvert.SerializeObject(createFriend);

            HttpClient httpClient = new HttpClient();

            var content = new StringContent(createFriendJson, Encoding.UTF8, "application/json");

            await httpClient.PostAsync("http://localhost:59614/api/friends", content);
        }
    }
}
