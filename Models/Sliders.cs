using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class Sliders
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public bool Statu { get; set; } = true;
    }
}