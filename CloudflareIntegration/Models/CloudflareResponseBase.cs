namespace CloudflareIntegration.Models
{
    public class CloudflareResponseBase<T> where T : class
    {
        public T Result { get; set; }

        public bool Success { get; set; }

        public Error[] Errors { get; set; }

        public string[] Messages { get; set; }

        public class Error
        {
            public string Code { get; set; }

            public string Message { get; set; }
        }
    }
}
