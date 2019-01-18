namespace CloudflareIntegration.Models
{
    public class CloudflareResponseBase<T> where T : class
    {
        public T Result { get; set; }

        public bool Success { get; set; }

        public string[] Errors { get; set; }

        public string[] Messages { get; set; }
    }
}
