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

namespace Tezca
{
    class Query
    {
        public int Tipo { get; set; }
        public List<string> Tablas { get; set; }
        public List<string> Valores { get; set; }
        public List<string> Extras { get; set; }

        public Query()
        {
            Tablas = new List<string>();
            Valores = new List<string>();
            Extras = new List<string>();
        }
    }
}