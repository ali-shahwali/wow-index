using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WowIndex.Data;

namespace WowIndex.Helpers
{
    public class AuthTokenHelper
    {
        public static HttpClient HttpClient()
        {
            string clientId = "1982e5a534d049c2be0c44fa9a4c3171";
            string clientSecret = "6J4G57M927DI3z3adm5iI3hIvn185CbG";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
            client.BaseAddress = new Uri($"https://eu.battle.net/oauth/token");

            return client;
        }



        public static async Task<Token> ValidateToken(ApplicationDbContext _context)
        {
            var TokenInDatabase = _context.Tokens.Where(x => x.ExpirationDate > DateTime.Now).FirstOrDefault();

            // NO TOKEN
            if (TokenInDatabase == null)
                return await GetNewToken(_context);
            else
                return TokenInDatabase;
        }



        public static async Task<Token> GetNewToken(ApplicationDbContext _context)
        {
            // Get new token (oauth access token, 24 hour TTL)
            var request = await HttpClient().PostAsync($"?grant_type=client_credentials&scope=wow.profile", null);
            string response = await request.Content.ReadAsStringAsync();
            string AccessToken = response.Split('"')[3];
            var newToken = new Token()
            {
                token = AccessToken,
                ExpirationDate = DateTime.Now.AddSeconds(86399),
                RequestsThisHour = 0
            };

            // this is so dumb but i need this if statment here or it will enter twice...
            if (_context.Tokens.FirstOrDefault() == null)
            {
                _context.Tokens.Add(newToken);
                _context.SaveChanges();
            }

            return newToken;
        }
    }
}
