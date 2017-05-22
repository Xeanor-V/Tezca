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
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Tezca
{
    [Activity(Label = "InfoActivity")]
    public class InfoActivity : Activity
    {
        private Communication comm;
        private ProductResponse response;
        private Query query;
        private int index = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.info);
            comm = new Communication();
            response = new ProductResponse();
            query = new Query();
            query.Tipo = 0;
            query.Tablas.Add("Producto");
            query.Valores.Add("Nombre");
            query.Valores.Add("Precio");
            query.Valores.Add("Descripcion");

            //HttpWebResponse httpResponse = comm.send(query);
            using (var httpReponse = (HttpWebResponse)comm.send(query))
            {

                using (var reader = new StreamReader(httpReponse.GetResponseStream()))
                {
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    response = (ProductResponse)JsonConvert.DeserializeObject(objText, typeof(ProductResponse));
                }

            }
            FindViewById<Button>(Resource.Id.ContButton).Click += OnContClick;
            // Create your application here
        }

        void OnContClick(object sender, EventArgs e)
        {

            FindViewById<TextView>(Resource.Id.NameText).Text = response.Nombre[index];
            FindViewById<TextView>(Resource.Id.PriceText).Text = response.Precio[index];
            FindViewById<TextView>(Resource.Id.DescText).Text = response.Descripcion[index];
            index++;
            index %= response.Nombre.Count;
           SetContentView(Resource.Layout.info);
        }
    }
}