using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
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
        HttpClient _httpClient = new HttpClient();

        public FriendApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.BaseAddress = new System.Uri("http://localhost:5000");
        }

        public async Task<PostFriendResult> PostAsync(CreateFriend createFriend)
        {
            var createFriendJson = JsonConvert.SerializeObject(createFriend);

            
            

            var content = new StringContent(createFriendJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Friends", content);

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

        public async Task <List<ListFriend>> GetAsync()
        {
            var response = await _httpClient.GetAsync("api/Friends");
            var responseContent = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ListFriend>>(responseContent);
            return list;
        }
    }
}
