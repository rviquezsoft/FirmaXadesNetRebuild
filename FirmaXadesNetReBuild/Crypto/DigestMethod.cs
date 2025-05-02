


using System;
using System.Security.Cryptography;

namespace FirmaXadesNetCore.Crypto
{
    public class DigestMethod
    {
        #region Private variables

        private string _name;
        private string _uri;
        private string _oid;

        #endregion

        #region Public properties

        public static DigestMethod SHA1 = new DigestMethod("SHA1", "http://www.w3.org/2000/09/xmldsig#sha1", "1.3.14.3.2.26");
        public static DigestMethod SHA256 = new DigestMethod("SHA256", "http://www.w3.org/2001/04/xmlenc#sha256", "2.16.840.1.101.3.4.2.1");
        public static DigestMethod SHA512 = new DigestMethod("SHA512", "http://www.w3.org/2001/04/xmlenc#sha512", "2.16.840.1.101.3.4.2.3");


        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string URI
        {
            get
            {
                return _uri;
            }
        }

        public string Oid
        {
            get
            {
                return _oid;
            }
        }

        #endregion

        #region Constructors

        private DigestMethod(string name, string uri, string oid)
        {
            _name = name;
            _uri = uri;
            _oid = oid;
        }

        #endregion

        #region Public methods

        public static DigestMethod GetByOid(string oid)
        {
            if (oid == SHA1.Oid)
            {
                return SHA1;
            }
            else if (oid == SHA256.Oid)
            {
                return SHA256;
            }
            else if (oid == SHA512.Oid)
            {
                return SHA512;
            }
            else
            {
                throw new Exception("Unsupported digest method");
            }
        }

        public HashAlgorithm GetHashAlgorithm()
        {
            if (_name == "SHA1")
            {
                return System.Security.Cryptography.SHA1.Create();
            }
            else if (_name == "SHA256")
            {
                return System.Security.Cryptography.SHA256.Create();
            }
            else if (_name == "SHA512")
            {
                return System.Security.Cryptography.SHA512.Create();
            }
            else
            {
                throw new Exception("Algoritmo no soportado");
            }
        }

        #endregion
    }
}
