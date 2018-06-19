using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class LipaMpesaPassword
    {
        public static string Password(string passkey, string shortcode, string timestamp)
        {
            var password =  shortcode + passkey + timestamp;
            //get bytes from string and convert utf8 or ascii any
            var bytes = Encoding.UTF8.GetBytes(password);
            //convert to base 64 string

            return Convert.ToBase64String(bytes);
        }
    }
}
