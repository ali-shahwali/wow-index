using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WowIndex.Data;

namespace WowIndex.Helpers
{
    public class AuthTokenHelper
    {
        public static HttpClient HttpClient(IConfiguration Configuration)
        {
            string clientId = Configuration["APIClientID"];
            string clientSecret = Configuration["APIClientSecret"];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));
            client.BaseAddress = new Uri($"https://eu.battle.net/oauth/token");

            return client;
        }



        public static async Task<Token> ValidateToken(ApplicationDbContext _context, IConfiguration Configuration)
        {
            var TokenInDatabase = _context.Tokens.Where(x => x.ExpirationDate > DateTime.Now).FirstOrDefault();

            // NO TOKEN
            if (TokenInDatabase == null)
                return await GetNewToken(_context, Configuration);
            else
                return TokenInDatabase;
        }



        public static async Task<Token> GetNewToken(ApplicationDbContext _context, IConfiguration Configuration)
        {
            // Get new token (oauth access token, 24 hour TTL)
            var request = await HttpClient(Configuration).PostAsync($"?grant_type=client_credentials&scope=wow.profile", null);
            string response = await request.Content.ReadAsStringAsync();
            string AccessToken = response.Split('"')[3];
            var newToken = new Token()
            {
                token = AccessToken,
                ExpirationDate = DateTime.Now.AddSeconds(86399),
                RequestsThisHour = 0
            };

            // this is so dumb but i need this if statment here or it will enter twice...

            _context.Tokens.Add(newToken);
            _context.SaveChanges();

            return newToken;
        }
    }
}
