using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1
{
    /*Learn about RSA*/
    public static class Security
    {
        public static String encryptInitiatorPassword(string securityCertificate, String password)
        {
            //write password to array
            var Passwd = Encoding.ASCII.GetBytes(password);
            String encryptedPassword = "YOUR_INITIATOR_PASSWORD";
            //Path to certificate
            try
            {
               
                X509Certificate2 x509cert = new X509Certificate2(securityCertificate);
                var h = x509cert.PublicKey.Key;

                //
                using (RSACryptoServiceProvider rsaprovider = (RSACryptoServiceProvider)x509cert.PublicKey.Key) {
                 
                     var encrypted = rsaprovider.Encrypt(Passwd, false);
                     encryptedPassword = Convert.ToBase64String(encrypted);
                   
                }
               
            }
            catch (Exception)
            {

                throw;
            }

            return encryptedPassword;
         
            
        }
    }
}
