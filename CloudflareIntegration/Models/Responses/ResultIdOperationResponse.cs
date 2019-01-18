namespace CloudflareIntegration.Models.Responses
{
    public class ResultIdOperationResponse : CloudflareResponseBase<ResultIdOperationResponse.ResultId>
    {
        public class ResultId
        {
            public string Id { get; set; }
        }
    }
}
