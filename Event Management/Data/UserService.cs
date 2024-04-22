using Event_Management.Models;
using Newtonsoft.Json;


namespace Event_Management.Data
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://gorest.co.in/public/v2/");
        }

 
        public IEnumerable<User> GetUsers()
        {
            var response = _httpClient.GetAsync("users").Result;
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<User>>(data);
        }
        public User GetUserById(int id)
        {
            var response = _httpClient.GetAsync($"users/{id}").Result;
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(data);
        }

        public void AddUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("users", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync($"users/{user.Id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteUser(int id)
        {
            var response = _httpClient.DeleteAsync($"users/{id}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
