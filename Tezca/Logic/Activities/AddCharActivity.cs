using System;
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
using Tezca.Logic.Comm;

namespace Tezca.Logic.Activities
{
    [Activity(Label = "AddCharActivity")]
    public class AddCharActivity : AppCompatActivity
    {
        private Element_Builder Ebuilder;
        private int NumChar;
        private int IdBegin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Addchar);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar_char);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Characteristics";
           
            NumChar = 5;
            IdBegin = 900;
            Ebuilder = new Element_Builder(this,IdBegin);
            FindViewById<LinearLayout>(Resource.Id.Char_LinearLayout).AddView(Ebuilder.Build_CharTop());
            FindViewById<Button>(Resource.Id.CContinueButton).Click += OnContinueButtonClick;

            // Create your application here
        }

        public void OnContinueButtonClick(object obj, EventArgs e)
        {
            Product_data Pdata = JsonConvert.DeserializeObject<Product_data>(Intent.GetStringExtra("Pdata"));

            for (int i = 6; i > NumChar; i--, IdBegin += 2)
            {
                String name = FindViewById<EditText>(IdBegin).Text;
                String desc = FindViewById<EditText>(IdBegin + 1).Text;
                if (name == "")
                {
                    Toast.MakeText(this, "Name cannot be null",
                       ToastLength.Short).Show();
                    return;
                }
                Pdata.Cname.Add(name);
                Pdata.Cdesc.Add(desc);
            }

            Query producto = new Query();
            producto.Tipo = 1;
            producto.Tablas.Add("producto(productoid,nombre,precio,descripcion,negocioid) ");

            int productiD = new Random().Next(1, 2024); //had to improvise for the moment, dont blame me
            string valor = "('" + +productiD + "','" + Pdata.Pname + "','" + Pdata.Pprice + "','" + Pdata.Pdesc + "','" + User_data.Instance.ID + "')";
            /*producto.Valores.Add(Pdata.Pname);
            producto.Valores.Add(Pdata.Pprice);
            producto.Valores.Add(Pdata.Pdesc);
            producto.Valores.Add(User_data.Instance.ID);*/
            producto.Valores.Add(valor);

            new Communication().send(producto);

            Query charac = new Query();
            charac.Tipo = 1;
            charac.Tablas.Add("Caracteristica(nombre,descripcion,productoid) ");
            for(int i = 0; i < Pdata.Cname.Count; i++)
            {
                charac.Valores.Add("('" + Pdata.Cname[i] + "','" + Pdata.Cdesc[i] + "','" + productiD + "')");
            }
            new Communication().send(charac);

            Intent intent = new Intent(this, typeof(ProductActivity));
            StartActivity(intent);
            Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.Char_Menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_return:
                    Finish();
                    break;

                case Resource.Id.menu_addChar:
                    if (NumChar == 0) break;
                    NumChar--;
                    FindViewById<LinearLayout>(Resource.Id.Char_LinearLayout).AddView(Ebuilder.Build_Char());
                    Toast.MakeText(this, "Char added",
                       ToastLength.Short).Show();
                    break;
            }
            // Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            //     ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}