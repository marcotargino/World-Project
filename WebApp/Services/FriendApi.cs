using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Friend;
using System.Net.Http.Headers;

namespace WebApp.Services
{
    public class FriendApi : IFriendApi
    {
        public async Task<PostFriendResult> PostAsync(CreateFriend createFriend)
        {
            var createFriendJson = JsonConvert.SerializeObject(createFriend);

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent(createFriendJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:59614/api/friends", content);

            if (response.IsSuccessStatusCode)
            {
                return new PostFriendResult { Success = true };
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<List<string>>(responseContent);
                return new PostFriendResult { Errors = errors};
            }
        }
    }

    public class PostFriendResult
    {
        public bool Success { get; set; }
        public List<String> Errors { get; set; }
    }
}
