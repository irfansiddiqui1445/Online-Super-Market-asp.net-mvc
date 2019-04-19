using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eproject.Models
{
    public class AsideView
    {


        public List<catagory> asidecat { get; set; }
        public List<brand> asidebrand { get; set; }
        public List<shop_vendor> asideshop { get; set; }
    }
}