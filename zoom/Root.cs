using System;
using System.Collections.Generic;
using System.Text;

namespace zoom
{
    public class Root
    {
        public int page_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
        public int total_records { get; set; }
        public List<User> users { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
