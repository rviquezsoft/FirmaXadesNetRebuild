

using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Upgraders.Parameters
{
    public class OcspServer
    {
        public const int DirectoryName = 4;
        public const int DnsName = 2;
        public const int EdiPartyName = 5;
        public const int IPAddress = 7;
        public const int OtherName = 0;
        public const int RegisteredID = 8;
        public const int Rfc822Name = 1;
        public const int UniformResourceIdentifier = 6;
        public const int X400Address = 3;

        public string Url { get; set; }

        public GeneralName RequestorName { get; private set; }

        public X509Certificate2 SignCertificate { get; set; }

        public OcspServer(string url)
        {
            this.Url = url;
        }

        public void SetRequestorName(int tag, string name)
        {
            this.RequestorName = new GeneralName(tag, name);
        }
    }
}
