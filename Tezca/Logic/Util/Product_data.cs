using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tezca.Logic.Util
{
    class Product_data
    {
       public string Pname { get; set; }
        public string Pprice { get; set; }
        public string Pdesc { get; set; }
        public List<string> Cname { get; set; }
        public List<string> Cdesc { get; set; }

        public Product_data()
        {
            Cname = new List<string>();
            Cdesc = new List<string>();
        }

        

    }
}