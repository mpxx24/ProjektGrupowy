using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ProjektG1.Models
{
    public class PHash
    {
        public string SHA1Hashuj(string haslo)
        {
            var buffer = Encoding.UTF8.GetBytes(haslo);
            var sha1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(sha1.ComputeHash(buffer)).Replace("-", "");
        }
    }
}