using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Authentication
    {
        public static string app_key = "0Wkr3uQbaA2pUMb2yixsN4oTQeQCdKbk";
        public static string app_secret = "bASd3L2DFbGe3Bcs";
       
    public static string Auth()
        {
            string appKeySecret = app_key + ":" + app_secret;
            byte[] bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(appKeySecret);
            string auth = Convert.ToBase64String(bytes);
            return auth;
        }
    }
}
