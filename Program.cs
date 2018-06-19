using ConsoleApp1.RegisterUrl;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("DR. Stickman Enterprise...!");

            HTTP_REQUEST requests = new HTTP_REQUEST();

            string basic = Authentication.Auth();
            Console.WriteLine("we on");
            string bearertoken = requests.SendRequest(basic);
            string certificate = @"C:\Users\derob\Desktop\cert.cer";
            MpesaModel b = new MpesaModel();
            RegisterURL url = new RegisterURL();
            NewMethod(b);
            //call the mpesa api Lipa online no need for Validation Url since money to be credited is hard coded.
            LipaMpesa.STKPush(b, bearertoken);
            //breakpoint halt 
            var date = DateTime.Now.ToString("yyyyMMddHHmmss");

           //var h = Security.encryptInitiatorPassword(certificate, "der");

        }

        private static void NewMethod(MpesaModel b)
        {
            b.BusinessShortCode = "174379";
            b.PartyA = "254703567954";
            b.PartyB = "174379";
            b.TransactionType = "CustomerPayBillOnline";
            b.Amount = "70";
            b.AccountReference = "ref";
            b.TransactionDesc = "Kupiga sherehe";
            b.CallBackURL = "http://ed2542f8.ngrok.io/confirm";
            b.Timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            b.Password = LipaMpesaPassword.Password("bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919", "174379", b.Timestamp);
            b.PhoneNumber = "254703567954";
        }
        //register url
        private static void RegisterUrL(RegisterURL url, string bearer)
        {
            url.ConfirmationURL = "";
            url.ResponseType = "Cancelled";
            url.Shortcode = "600753";
            url.ValidationURL = "";
        }

    }
}
