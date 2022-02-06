using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_front_page.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Stock { get; set; }
        public bool Statu { get; set; }
        public DateTime AddedDate { get; set; }= DateTime.Now;  


    }
}