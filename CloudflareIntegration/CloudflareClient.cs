using CloudflareIntegration.Models;
using CloudflareIntegration.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudflareIntegration
{
    public class CloudflareClient
    {
        private readonly HttpClient _client = new HttpClient();

        private readonly string _email;
        private readonly string _apiKey;

        //გადაწყობისას კონფიგურაციიდან წაკითხვა ან პარამეტრებად გადმოცემა
        public CloudflareClient()
        {
            _email = "kote.kargareteli@gmail.com";
            _apiKey = "0cd2b200ce8b196f970d36229798fefeb274f";
        }

        public async Task<ZoneOperationResponse> CreateZone(ZoneModel zone)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var requestJson = JsonConvert.SerializeObject(zone);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://api.cloudflare.com/client/v4/zones", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ZoneOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create zone, see inner exception for details", e);
            }
        }

        #region DNS

        public async Task<DNSListOperationResponse> DNSRecordsList(string zoneId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var response = await client.GetAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/dns_records");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DNSListOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to query DNS records, see inner exception for details", e);
            }
        }

        public async Task<DNSOperationResponse> CreateDNSRecord(string domainId, DNSRecordModel dnsRecord)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var serializedRecord = JsonConvert.SerializeObject(dnsRecord);
                    var requestContent = new StringContent(serializedRecord, Encoding.UTF8, "application/json");

                    var response = await _client.PostAsync($"https://api.cloudflare.com/client/v4/zones/{domainId}/dns_records", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DNSOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create DNS record, see inner exception for details", e);
            }
        }

        public async Task<ResultIdOperationResponse> DeleteDNSRecord(string domainId, string dnsId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var response = await _client.DeleteAsync($"https://api.cloudflare.com/client/v4/zones/{domainId}/dns_records/{dnsId}");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ResultIdOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete DNS record, see inner exception for details", e);
            }
        }

        #endregion

        public async Task<SubscriptionOperationResponse> SubscriptionDetails(string zoneId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var response = await client.GetAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/subscription");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SubscriptionOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to query subscription, see inner exception for details", e);
            }
        }

        public async Task<SubscriptionOperationResponse> CreateSubscription(string zoneId, SubscriptionModel subscription)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var requestJson = JsonConvert.SerializeObject(subscription);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/subscription", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SubscriptionOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create subscription, see inner exception for details", e);
            }
        }

        public async Task<ChangeSSLSettingOperationResponse> ChangeSSLSetting(string zoneId, SSLSettingModel sslSetting)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
                    client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

                    var requestJson = JsonConvert.SerializeObject(sslSetting);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PatchAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/settings/ssl", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ChangeSSLSettingOperationResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to switch ssl to flexible, see inner exception for details", e);
            }
        }

        public async void OrderCertificate()
        {
            _client.DefaultRequestHeaders.Add("X-Auth-Email", _email);
            _client.DefaultRequestHeaders.Add("X-Auth-Key", _apiKey);

            var certificatePackModel = new CertificateObjectModel
            {
                hosts = new[] { "sportingbit.com" }
            };

            var requestJson = JsonConvert.SerializeObject(certificatePackModel);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://api.cloudflare.com/client/v4/zones/a957cc9ce77392174f61eaf3e9fe5f4c/ssl/certificate_packs", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.IsSuccessStatusCode);
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
    }
}
