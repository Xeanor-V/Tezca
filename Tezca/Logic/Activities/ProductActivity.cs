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
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Tezca.Logic.Comm;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Tezca.Logic.Activities
{
    [Activity(Label = "ProductActivity")]
    public class ProductActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            User_data Udata = User_data.Instance;

            // FindViewById<TextView>(Resource.Id.Pp).Text = UserData.PassH[0];
            SetContentView(Resource.Layout.Products);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar_main);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = Udata.BName;

            LinearLayout Playout = FindViewById<LinearLayout>(Resource.Id.product_LinearLayout);

            Query productos = new Query();
            productos.Tipo = 0;
            productos.Tablas.Add("producto");
            productos.Valores.Add("Nombre");
            productos.Extras.Add("NegocioID ='" + User_data.Instance.ID + "'");
            Communication comm = new Communication();

            ProductResponse response = new ProductResponse();
            using (var httpReponse = (HttpWebResponse)comm.send(productos))
            {
                if (httpReponse == null)
                {
                    Toast.MakeText(this, "Connection error",
                    ToastLength.Short).Show();
                    return;
                }
                using (var reader = new StreamReader(httpReponse.GetResponseStream()))
                {
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    response = (ProductResponse)JsonConvert.DeserializeObject(objText, typeof(ProductResponse));
                }
            }

            for (int i = 0; i < response.Nombre.Count; i++)
                FindViewById<LinearLayout>(Resource.Id.product_LinearLayout).AddView(new Element_Builder(this, 0).Build_Card(response.Nombre[i]));
            /*var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "My Toolbar";*/
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_add:
                    Intent intent = new Intent(this, typeof(AddProductActivity));
                    StartActivity(intent);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }

}