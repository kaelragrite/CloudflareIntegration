using System;

namespace CloudflareIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new CloudflareClient();

            client.ChangeSSLSetting("a957cc9ce77392174f61eaf3e9fe5f4c", new Models.SSLSettingModel { value = Models.SSLSettingModel.SSLSettingValue.flexible });

            Console.ReadKey();
        }
    }
}
