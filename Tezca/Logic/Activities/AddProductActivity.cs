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
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Tezca.Logic.Util;
using Newtonsoft.Json;

namespace Tezca.Logic.Activities
{
    [Activity(Label = "AddProductActivity")]
    public class AddProductActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           

            // FindViewById<TextView>(Resource.Id.Pp).Text = UserData.PassH[0];
            SetContentView(Resource.Layout.Addproduct);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar_create);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "New Product";

            FindViewById<Button>(Resource.Id.PContinueButton).Click += OnContinueClick;

            
        }

        public void OnContinueClick(object sender, EventArgs e)
        {
            Product_data PData = new Product_data();
            PData.Pname = FindViewById<EditText>(Resource.Id.Pname).Text;
            PData.Pprice = FindViewById<EditText>(Resource.Id.Pprice).Text;
            PData.Pdesc = FindViewById<EditText>(Resource.Id.Pdesc).Text;

            Intent intent = new Intent(this, typeof(AddCharActivity));
            intent.PutExtra("Pdata", JsonConvert.SerializeObject(PData));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Add_Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_return:
                    Finish();
                    break;
                
            }
           // Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
           //     ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}