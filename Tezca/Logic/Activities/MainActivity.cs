using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
namespace Tezca.Logic.Activities
{
    [Activity(Label = "Tezca", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button InfoButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
           // InfoButton = FindViewById<Button>(Resource.Id.InfoButton);
            FindViewById<Button>(Resource.Id.RegisterButton).Click += OnRegisterClick;
            
           // InfoButton.Click += OnInfoClick;
        }

        void OnRegisterClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        void OnAddItemClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AddItemActivity));
            StartActivity(intent);
        }
        void OnInfoClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InfoActivity));
            StartActivity(intent);
            
        }
    }
}

