using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp1
{
    public class HTTP_REQUEST
    {
        public string SendRequest(string auth)
        {
            string results = "d";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage message = client.GetAsync("https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials").Result;

                    if (message.IsSuccessStatusCode)
                    {
                        var bearer = message.Content.ReadAsStringAsync().Result;

                        var baer = JObject.Parse(bearer);

                        results = baer.GetValue("access_token").ToString();
                        
                    }
                }
            }
            catch (WebException)
            {

                throw;
            }

            return results;
        }
        
        

    }
}
