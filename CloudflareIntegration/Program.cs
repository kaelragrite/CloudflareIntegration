using System;

namespace CloudflareIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new CloudflareClient();

            client.ChangeAlwaysUseHTTPSSetting("a957cc9ce77392174f61eaf3e9fe5f4c", new Models.AlwaysUseHTTPSSetting { value = Models.AlwaysUseHTTPSSetting.AlwaysUseHTTPSSettingValue.on });

            Console.ReadKey();
        }
    }
}
