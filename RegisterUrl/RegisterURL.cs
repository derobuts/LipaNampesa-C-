using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.RegisterUrl
{
    public class RegisterURL
    {
        string ValidationURL1;
        string ResponseType1;
        string ConfirmationURL1;
        string Shortcode1;
        public string ValidationURL { get => ValidationURL1; set => ValidationURL1 = value; }
        public string ConfirmationURL { get => ConfirmationURL1; set => ConfirmationURL1 = value;}
        public string Shortcode { get => Shortcode1; set => Shortcode1 = value; }
        public string ResponseType { get => ResponseType1; set => ResponseType1 = value; }
    }
}
