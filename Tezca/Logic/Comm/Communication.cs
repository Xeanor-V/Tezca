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

namespace Tezca.Logic.Comm
{
    class Communication
    {
        public HttpWebResponse send(Query query)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://davidvega.azurewebsites.net/Tezca");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            try
            { 
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(query);

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                return httpResponse;
            }
            catch(WebException we)
            {
                return null;
            }
            /*using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }*/
        }
    }
}