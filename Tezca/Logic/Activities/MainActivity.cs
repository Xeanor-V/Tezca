using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Tezca.Logic.Util;
using Tezca.Logic.Comm;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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
            FindViewById<Button>(Resource.Id.LoginButton).Click += OnLoginClick;
            // InfoButton.Click += OnInfoClick;
          
          /* var intent = new Intent(this, typeof(AddCharActivity));
           StartActivity(intent);*/
        }

        void OnRegisterClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        void OnLoginClick(object sender, EventArgs e)
        {
            EditText Login = FindViewById<EditText>(Resource.Id.LoginText);
            EditText Pass = FindViewById<EditText>(Resource.Id.PassText);
            Query query = new Query();
            Communication comm = new Communication();
            query.Tipo = 0;


            int HU = new Hash_Machine().getHash(Login.Text);
            int HP = new Hash_Machine().getHash(Pass.Text);

            query.Tablas.Add("Negocio");
            query.Valores.Add("usuarioH");
            query.Valores.Add("passH");
            query.Valores.Add("Nombre");
            query.Valores.Add("NegocioID");

            query.Extras.Add("usuarioH = '" + HU + "' ");
            query.Extras.Add("passH = '" + HP + "' ");

            UserResponse response = new UserResponse();

            using (var httpReponse = (HttpWebResponse)comm.send(query))
            {
                if(httpReponse == null)
                {
                    Toast.MakeText(this, "Connection error",
                    ToastLength.Short).Show();
                    return;
                }
                using (var reader = new StreamReader(httpReponse.GetResponseStream()))
                {
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();
                    response = (UserResponse)JsonConvert.DeserializeObject(objText, typeof(UserResponse));
                }
            }

            if (response.UsuarioH.Count == 1 && response.PassH.Count == 1)
            {
                User_data Udata = User_data.Instance;
                Udata.User = response.UsuarioH[0];
                Udata.BName = response.Nombre[0];
                Udata.ID = response.NegocioID[0];
                Intent intent = new Intent(this, typeof(ProductActivity));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(this, "Incorrect user or password",
                    ToastLength.Short).Show();
            }

        }

        void OnAddItemClick(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(AddItemActivity));
            //StartActivity(intent);
        }
        void OnInfoClick(object sender, EventArgs e)
        {
            
            //Intent intent = new Intent(this, typeof(InfoActivity));
            //StartActivity(intent);
            
        }
    }
}

