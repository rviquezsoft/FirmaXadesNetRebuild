

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Utils
{
    static class X509Certificate2Extensions
    {
        public static string GetSerialNumberAsDecimalString(this X509Certificate2 certificate)
        {            
            List<int> dec = new List<int> { 0 };
            
            foreach (char c in certificate.SerialNumber)
            {
                int carry = Convert.ToInt32(c.ToString(), 16);

                for (int i = 0; i < dec.Count; ++i)
                {
                    int val = dec[i] * 16 + carry;
                    dec[i] = val % 10;
                    carry = val / 10;
                }

                while (carry > 0)
                {
                    dec.Add(carry % 10);
                    carry /= 10;
                }
            }

            var chars = dec.Select(d => (char)('0' + d));
            var cArr = chars.Reverse().ToArray();
            return new string(cArr);
        }

        public static Org.BouncyCastle.X509.X509Certificate ToBouncyX509Certificate(this X509Certificate2 certificate)
        {
            return new Org.BouncyCastle.X509.X509CertificateParser().ReadCertificate(certificate.GetRawCertData());
        }
    }
}
