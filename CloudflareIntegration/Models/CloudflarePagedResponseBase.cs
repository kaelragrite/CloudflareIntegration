namespace CloudflareIntegration.Models
{
    public class CloudflarePagedResponseBase<T> : CloudflareResponseBase<T> where T : class
    {
        public int Page { get; set; }

        public int Per_Page { get; set; }

        public string Order { get; set; }

        public string Direction { get; set; }
    }
}
