using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WowIndex.Data;

namespace WowIndex.Helpers
{
    public class AuthTokenHelper
    {

        /// <summary>
        /// Validates Oauth2 token
        /// </summary>
        /// <param name="_context">Database context</param>
        /// <param name="forceRefresh">Set to true if request fails for desync issues</param>
        /// <returns></returns>
        public static async Task ValidateToken(ApplicationDbContext _context, bool forceRefresh)
        {
            var storedToken = _context.Tokens.FirstOrDefault();
            if (forceRefresh || storedToken == null || storedToken.ExpirationDate < DateTime.Now)
            {
                var rows = from x in _context.Tokens select x;
                _context.RemoveRange(rows);
                _context.SaveChanges();

                string clientId = "1982e5a534d049c2be0c44fa9a4c3171";
                string clientSecret = "6J4G57M927DI3z3adm5iI3hIvn185CbG";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri($"https://eu.battle.net/oauth/token");

                // query parameters
                string grantType = "client_credentials";

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));

                // Send request
                var request = await client.PostAsync($"?grant_type={grantType}&scope=wow.profile", null);

                string response = await request.Content.ReadAsStringAsync();

                // oauth access token, 24 hour TTL
                string AccessToken = response.Split('"')[3];

                Data.Token newToken = new Data.Token()
                {
                    token = AccessToken,
                    ExpirationDate = DateTime.Now.AddSeconds(86399),
                };

                _context.Tokens.Add(newToken);
                _context.SaveChanges();
            }
        }
    }
}
