using System;

namespace CloudflareIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new CloudflareClient();

            client.OrderCertificate();

            Console.ReadKey();
        }
    }
}
