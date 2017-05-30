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
    public  class User_data
    {
        private static readonly User_data instance = new User_data();
        public  string ID { get; set; }
        public  string User { get; set; }
        public  string BName { get; set; }
        public  string Email { get; set; }

        private User_data() { }

        public static User_data Instance
        {
            get
            {
                return instance;
            }
        }

    }
}