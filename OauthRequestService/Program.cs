﻿using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OauthRequestService
{
    class OauthGenerator
    {
        public async Task getToken(string clientId, string clientSecret)
        {
            string str = NavigationManager.Uri.Split('/')[3];
            if (str.Equals("refreshProfile"))
            {
                // build request
                var client = new HttpClient();
                client.BaseAddress = new Uri($"https://{region}.battle.net/oauth/authorize");
                string responseType = "code";
                string redirectURI = $"https%3A%2F%2Flocalhost%3A44374%2Fauthorize%2F{region}";
                string scope = "wow.profile";

                // send request
                var auth = await client.GetAsync($"?response_type={responseType}&client_id={clientId}&redirect_uri={redirectURI}&scope={scope}");

                // navigate to ruturn url
                NavigationManager.NavigateTo(auth.RequestMessage.RequestUri.OriginalString);
            }
        }
    }
}