using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp1
{
    public static class LipaMpesa
    {
       
        public static bool STKPush(MpesaModel p, string bearer)
        {
            bool flag = false;
            //serialize the LipaMpesa class object
            string json = JsonConvert.SerializeObject(p);
            //StringContent stringcontent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = new Uri("https://sandbox.safaricom.co.ke/mpesa/stkpush/v1/processrequest");
            try
            {
                //send post request using bytes
                HttpWebRequest httpWreq = (HttpWebRequest)WebRequest.Create(url);
                //HTTPAuthorization Header string Format
                string authorize = string.Format("{0} {1}","Bearer", bearer);
                //Since i'll be working
                byte[] data = Encoding.UTF8.GetBytes(json);
                httpWreq.Method = "POST";
                httpWreq.ContentType = "application/json";
                httpWreq.Headers[HttpRequestHeader.Authorization] = authorize;
                using (var stream = httpWreq.GetRequestStream())
                {
                    //
                    stream.Write(data, 0, data.Length);
                    //
                    
                    //
                   
                    HttpWebResponse response = (HttpWebResponse)httpWreq.GetResponse();
                    string s = response.ToString();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    
                    string temp;
                    string jsonresponse = "b";
                    while ((temp = reader.ReadLine()) != null)
                    {
                        jsonresponse += temp;
                    }
                    int b = 10;
                    
                }
                return true;
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                    }
                }
                return flag;
            }

           
        }
    }
}
