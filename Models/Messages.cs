using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public bool IsRead { get; set; } = false;
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string IpAdress { get; set; }
    }
}