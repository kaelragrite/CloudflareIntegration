namespace CloudflareIntegration.Models
{
    public class AddZoneRequestModel
    {
        public string name { get; set; }

        public bool jump_start { get; set; }

        public Account account { get; set; }

        public class Account
        {
            public string id { get; set; }

            public string name { get; set; }
        }
    }
}
