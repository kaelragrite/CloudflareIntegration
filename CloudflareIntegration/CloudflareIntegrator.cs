using CloudflareIntegration.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CloudflareIntegration
{
    public class CloudflareIntegrator
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly string _email = "kote.kargareteli@gmail.com";
        private readonly string _apiKey = "0cd2b200ce8b196f970d36229798fefeb274f";

        public async void AccountDetails()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var response = await _client.GetAsync("https://api.cloudflare.com/client/v4/accounts/a1674829d9aacba53c9a317a6f19d225");

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(content);
        }

        public async void ZonesList()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var response = await _client.GetAsync("https://api.cloudflare.com/client/v4/zones?name=sportingbit.com&status=active&page=1&per_page=20&order=status&direction=desc&match=all");

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(content);
        }

        public async void ZoneDetails()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var response = await _client.GetAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c");

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(content);
        }

        public async void CreateZone()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var requestModel = new AddZoneRequestModel
            {
                name = "sportingbit.com",
                jump_start = true,
                account = new AddZoneRequestModel.Account
                {
                    id = "a1674829d9aacba53c9a317a6f19d225",
                    name = "Kote.kargareteli@gmail.com's Account"
                }
            };

            var requestJson = JsonConvert.SerializeObject(requestModel);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://api.cloudflare.com/client/v4/zones", requestContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(responseContent);
        }

        public async void DeleteZone()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var response = await _client.DeleteAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c");

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }

        public async void AlwaysUseHttps()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var requestContent = new StringContent("{\"value\": \"on\"}", Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c/settings/always_use_https", requestContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }

        public async void FlexibleSSL()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var requestContent = new StringContent("{\"value\": \"flexible\"}", Encoding.UTF8, "application/json");
            var response = await _client.PatchAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c/settings/ssl", requestContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }

        public async void ListSubscription()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var response = await _client.GetAsync("https://api.cloudflare.com/client/v4/accounts/a1674829d9aacba53c9a317a6f19d225/subscriptions");
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }

        public async void CreateSubscription()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var createSubscriptionRequest = new CreateSubscriptionRequestModel
            {
                app = new CreateSubscriptionRequestModel.App
                {
                    install_id = null
                },
                id = Guid.NewGuid().ToString(),
                state = "Trial",
                price = 20,
                currency = "USD",
                component_values = Enumerable.Empty<CreateSubscriptionRequestModel.ComponentValue>(),
                zone = new CreateSubscriptionRequestModel.Zone
                {
                    id = "a957cc9ce77392174f61eaf3e9fe5f4c",
                    name = "sportingbit.com"
                },
                frequency = "monthly",
                rate_plan = new CreateSubscriptionRequestModel.RatePlan
                {
                    id = "free",
                    public_name = "Business Plan",
                    currency = "USD",
                    scope = "zone",
                    externally_managed = false
                },
                current_period_end = DateTime.Now,
                current_period_start = DateTime.Now.AddYears(1)
            };

            var requestJson = JsonConvert.SerializeObject(createSubscriptionRequest);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://api.cloudflare.com/client/v4/accounts/a1674829d9aacba53c9a317a6f19d225/subscriptions", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(responseContent);
        }

        public async void OrderCertificatePack()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var certificatePackModel = new CertificatePackObjectModel
            {
                hosts = new[] { "www.sportingbit.com", "sport.sportingbit.com" }
            };

            var requestJson = JsonConvert.SerializeObject(certificatePackModel);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c/ssl/certificate_packs", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(responseContent);
        }
    }
}
