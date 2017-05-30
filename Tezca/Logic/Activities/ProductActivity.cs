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
using Tezca.Logic.Util;
using Android.Support.V7.Widget;


namespace Tezca.Logic.Activities
{
    [Activity(Label = "ProductActivity")]
    public class ProductActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            User_data Udata = User_data.Instance;
            
            // FindViewById<TextView>(Resource.Id.Pp).Text = UserData.PassH[0];
            SetContentView(Resource.Layout.Products);
            //CardView card = new CardView();

            // Create your application here
        }
    }

}