namespace CloudflareIntegration.Models.Responses
{
    public class ResultIdResponse : CloudflareResponseBase<ResultIdResponse.ResultId>
    {
        public class ResultId
        {
            public string Id { get; set; }
        }
    }
}
