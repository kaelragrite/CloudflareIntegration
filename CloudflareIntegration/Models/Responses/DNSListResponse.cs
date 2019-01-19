using System.Collections.Generic;

namespace CloudflareIntegration.Models.Responses
{
    public class DNSListResponse : CloudflarePagedResponseBase<IEnumerable<DNSRecordModel>> { }
}
