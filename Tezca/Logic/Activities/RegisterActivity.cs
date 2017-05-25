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
using Tezca.Logic.Comm;
using Tezca.Logic.Util;

namespace Tezca.Logic.Activities
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        private EditText User, Bname, Email, Pass1, Pass2;
        private Button Register;
        private ProgressBar Pbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            User = FindViewById<EditText>(Resource.Id.User);
            Bname = FindViewById<EditText>(Resource.Id.Bname);
            Email = FindViewById<EditText>(Resource.Id.Email);
            Pass1 = FindViewById<EditText>(Resource.Id.Pass1);
            Pass2 = FindViewById<EditText>(Resource.Id.Pass2);
            Register = FindViewById<Button>(Resource.Id.RegisterButton);
            Pbar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            Register.Click += OnRegisterClick;


            // Create your application here
        }


        public void OnRegisterClick(object sender, EventArgs e)
        {
            if(!Pass1.Text.Equals(Pass2.Text))
            {
                Pass1.Hint = "Passwords must match!";
                Pass1.SetText("", TextView.BufferType.Editable);
                Pass2.SetText("", TextView.BufferType.Editable);
                return;
            }
            Pass1.Hint = "Password";
            Register.Enabled = false;
           Register.Visibility = ViewStates.Invisible;
            Pbar.Visibility = ViewStates.Visible;

            Hash_Machine hasher = new Hash_Machine();
            Communication comm = new Communication();
            Query negocioQuery = new Query();
            negocioQuery.Tipo = 1;
            negocioQuery.Tablas.Add("Negocio(Nombre,UsuarioH,PassH) ");
            negocioQuery.Valores.Add(Bname.Text);
            negocioQuery.Valores.Add(""+hasher.getHash(User.Text));
            negocioQuery.Valores.Add(""+hasher.getHash(Bname.Text));
            comm.send(negocioQuery);
            Query contactoQuery = new Query();
            contactoQuery.Tipo = 1;
            contactoQuery.Tablas.Add("Contacto");
            contactoQuery.Valores.Add("" + new Random().Next(1, 2024));
            contactoQuery.Valores.Add(Email.Text);
            contactoQuery.Valores.Add("-");
            comm.send(contactoQuery);


        }

    }
}