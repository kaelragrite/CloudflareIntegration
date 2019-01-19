﻿using System;

namespace CloudflareIntegration.Models
{
    public class ZoneModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public int development_mode { get; set; }

        public string[] original_name_servers { get; set; }

        public string original_registrar { get; set; }

        public string original_dnshost { get; set; }

        public DateTime created_on { get; set; }

        public DateTime modified_on { get; set; }

        public DateTime? activated_on { get; set; }

        public Owner owner { get; set; }

        public Account account { get; set; }

        public string[] permissions { get; set; }

        public Plan plan { get; set; }

        public Plan plan_pending { get; set; }

        public string status { get; set; }

        public bool paused { get; set; }

        public string type { get; set; }

        public bool jump_start { get; set; }

        public class Owner
        {
            public string id { get; set; }

            public string email { get; set; }

            public string name { get; set; }

            public string type { get; set; }
        }

        public class Account
        {
            public string id { get; set; }

            public string name { get; set; }
        }

        public class Plan
        {
            public string id { get; set; }

            public string name { get; set; }

            public decimal price { get; set; }

            public string currency { get; set; }

            public string frequency { get; set; }

            public string legacy_id { get; set; }

            public bool is_subscribed { get; set; }

            public bool can_subscribe { get; set; }
        }
    }
}
