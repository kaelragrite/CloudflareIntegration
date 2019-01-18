using System.Collections.Generic;

namespace CloudflareIntegration.Models.Responses
{
    public class DNSListOperationResponse : CloudflarePagedResponseBase<IEnumerable<DNSRecordObjectModel>> { }
}
