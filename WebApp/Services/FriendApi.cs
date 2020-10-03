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
            _httpClient.BaseAddress = new System.Uri("http://localhost:5000/");
        }

        public async Task<CreateFriend> PostAsync(CreateFriend createFriend)
        {
            var createFriendJson = JsonConvert.SerializeObject(createFriend);
            var content = new StringContent(createFriendJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Friends", content);

            if (response.IsSuccessStatusCode)
            {
                return createFriend;
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<List<string>>(responseContent);
                createFriend.Errors = errors;
            }

            return createFriend;
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


/*
 
public async Task<CriarAmigoViewModel> PostAmigo(CriarAmigoViewModel criarPaisViewModel)
        {
            var criarPaisViewModelJson = JsonConvert.SerializeObject(criarPaisViewModel);

            var conteudo = new StringContent(criarPaisViewModelJson, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("https://localhost:44328/api/amigos", conteudo);

            return criarPaisViewModel;
        }
 
 */