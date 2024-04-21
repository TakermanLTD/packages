﻿using System.Text;
using Takerman.Mixer.Services.Providers;

namespace Takerman.Marketplace.Providers
{
    public interface IOlxProvider
    {
    }

    public class OlxProvider : BaseProvider, IOlxProvider
    {
        private static async Task GetTokenAsync()
        {
            HttpClient client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.olx.bg/open/oauth/token");

            request.Content = new StringContent(
                "{\"grant_type\": \"\", \"client_id\": \"\", \"client_secret\": \"\", \"scope\": \"v2 read write\"}",
                Encoding.UTF8,
                "application/json");

            var response = await client.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}