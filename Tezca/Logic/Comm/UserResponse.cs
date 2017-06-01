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
    public class UserResponse
    {
        public List<string> UsuarioH { get; set; }
        public List<string> PassH { get; set; }
        public List<string> Nombre { get; set; }
        public List<string> NegocioID { get; set; }

    }
}