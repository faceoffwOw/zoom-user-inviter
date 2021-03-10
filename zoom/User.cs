using System;
using System.Collections.Generic;
using System.Text;

namespace zoom
{
    public class User
    {
        public DateTime created_at { get; set; }
        public string dept { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public List<string> group_ids { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string last_client_version { get; set; }
        public DateTime last_login_time { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public int pmi { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public int type { get; set; }
        public int verified { get; set; }
        public string pic_url { get; set; }
    }
}
