using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string AdminAbout { get; set; }


    }
}