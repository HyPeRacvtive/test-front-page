using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_front_page.Models
{
    public class SocialMedia
    {
        public int Id { get; set; }
        [AllowHtml]
        public string FaceBook { get; set; }
        [AllowHtml] 
        public string Instagram { get; set; }
        [AllowHtml]
        public string Youtube { get; set; }
    }
}