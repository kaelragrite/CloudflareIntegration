using CloudflareIntegration.Models;
using CloudflareIntegration.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudflareIntegration
{
    public class CloudflareClient
    {
        private readonly string _email;
        private readonly string _apiKey;

        // config or DI
        public CloudflareClient()
        {
            _email = string.Empty;
            _apiKey = string.Empty;
        }

        public async Task<ZoneResponse> CreateZone(ZoneModel zone)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var requestJson = JsonConvert.SerializeObject(zone);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://api.cloudflare.com/client/v4/zones", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ZoneResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create zone, see inner exception for details", e);
            }
        }

        #region DNS

        public async Task<DNSListResponse> DNSRecordsList(string zoneId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var response = await client.GetAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/dns_records");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DNSListResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to query DNS records, see inner exception for details", e);
            }
        }

        public async Task<DNSResponse> CreateDNSRecord(string domainId, DNSRecordModel dnsRecord)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var serializedRecord = JsonConvert.SerializeObject(dnsRecord);
                    var requestContent = new StringContent(serializedRecord, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"https://api.cloudflare.com/client/v4/zones/{domainId}/dns_records", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DNSResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create DNS record, see inner exception for details", e);
            }
        }

        public async Task<ResultIdResponse> DeleteDNSRecord(string domainId, string dnsId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var response = await client.DeleteAsync($"https://api.cloudflare.com/client/v4/zones/{domainId}/dns_records/{dnsId}");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ResultIdResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to delete DNS record, see inner exception for details", e);
            }
        }

        #endregion

        public async Task<SubscriptionResponse> SubscriptionDetails(string zoneId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var response = await client.GetAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/subscription");
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SubscriptionResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to query subscription, see inner exception for details", e);
            }
        }

        public async Task<SubscriptionResponse> CreateSubscription(string zoneId, SubscriptionModel subscription)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var requestJson = JsonConvert.SerializeObject(subscription);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/subscription", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<SubscriptionResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to create subscription, see inner exception for details", e);
            }
        }

        public async Task<CertificatePackResponse> OrderCertificatePack(string zoneId, CertificatePackModel certificatePack)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var requestJson = JsonConvert.SerializeObject(certificatePack);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/ssl/certificate_packs", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<CertificatePackResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to order certificate pack, see inner exception for details", e);
            }
        }

        #region Settings

        public async Task<ChangeSSLSettingResponse> ChangeSSLSetting(string zoneId, SSLSettingModel sslSetting)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var requestJson = JsonConvert.SerializeObject(sslSetting);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PatchAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/settings/ssl", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<ChangeSSLSettingResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to switch ssl to flexible, see inner exception for details", e);
            }
        }

        public async Task<AlwaysUseHTTPSSettingResponse> ChangeAlwaysUseHTTPSSetting(string zoneId, AlwaysUseHTTPSSetting alwaysUseHTTPSSetting)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(Constants.AuthEmail, _email);
                    client.DefaultRequestHeaders.Add(Constants.AuthKey, _apiKey);

                    var requestJson = JsonConvert.SerializeObject(alwaysUseHTTPSSetting);
                    var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

                    var response = await client.PatchAsync($"https://api.cloudflare.com/client/v4/zones/{zoneId}/settings/always_use_https", requestContent);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<AlwaysUseHTTPSSettingResponse>(responseContent);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to change always use https setting, see inner exception for details", e);
            }
        }

        #endregion
    }
}
