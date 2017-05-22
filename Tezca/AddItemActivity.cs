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
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        private Communication comm;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Additem);
            comm = new Communication();
            FindViewById<Button>(Resource.Id.saveButton).Click += OnSaveClick;
            // Create your application here
        }

        void OnSaveClick(object sender, EventArgs e)
        {
            Query query = new Query();
            query.Tipo = 1;
            query.Tablas.Add("Producto");
            int id = new Random().Next(1024);
            string name = FindViewById<EditText>(Resource.Id.nameInput).Text;
            string price = FindViewById<EditText>(Resource.Id.PriceInput).Text;
            string desc = FindViewById<EditText>(Resource.Id.DescInput).Text;

            query.Valores.Add("" + id);
            query.Valores.Add(name);
            query.Valores.Add(price);
            query.Valores.Add(desc);
            query.Valores.Add("1");
            comm.send(query);

            StartActivity(typeof(MainActivity));
        }
    }
}