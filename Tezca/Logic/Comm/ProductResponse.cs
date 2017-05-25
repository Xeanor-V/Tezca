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

namespace Tezca.Logic.Comm
{
    class ProductResponse
    {
        public List<string> Nombre { get; set; }
        public List<string> Precio { get; set; }
        public List<string> Descripcion { get; set; }
    }
}