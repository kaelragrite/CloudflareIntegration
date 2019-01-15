using System;
using System.Collections.Generic;

namespace CloudflareIntegration.Models
{
    public class CreateSubscriptionRequestModel
    {
        public App app { get; set; }

        public DateTime current_period_end { get; set; }

        public IEnumerable<ComponentValue> component_values { get; set; }

        public RatePlan rate_plan { get; set; }

        public decimal price { get; set; }

        public DateTime current_period_start { get; set; }

        public Zone zone { get; set; }

        public string currency { get; set; }

        public string state { get; set; }

        public string id { get; set; }

        public string frequency { get; set; }

        public class App
        {
            public string install_id { get; set; }
        }

        public class ComponentValue
        {
            public string name { get; set; }

            public decimal value { get; set; }

            public decimal @default { get; set; }

            public decimal price { get; set; }
        }

        public class RatePlan
        {
            public string id { get; set; }

            public string public_name { get; set; }

            public string currency { get; set; }
            
            public string scope { get; set; }

            public bool externally_managed { get; set; }
        }

        public class Zone
        {
            public string id { get; set; }

            public string name { get; set; }
        }
    }
}
