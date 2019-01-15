using System;

namespace CloudflareIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cloudflareIntegrator = new CloudflareIntegrator();

            cloudflareIntegrator.CreateSubscription();

            Console.ReadKey();
        }
    }
}
