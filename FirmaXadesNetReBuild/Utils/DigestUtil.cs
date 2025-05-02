

using Microsoft.Xades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FirmaXadesNetCore.Crypto;

namespace FirmaXadesNetCore.Utils
{
    class DigestUtil
    {
        #region Public methods

        public static void SetCertDigest(byte[] rawCert, FirmaXadesNetCore.Crypto.DigestMethod digestMethod, DigestAlgAndValueType destination)
        {
            using (var hashAlg = digestMethod.GetHashAlgorithm())
            {
                destination.DigestMethod.Algorithm = digestMethod.URI;
                destination.DigestValue = hashAlg.ComputeHash(rawCert);
            }
        }

        public static byte[] ComputeHashValue(byte[] value, FirmaXadesNetCore.Crypto.DigestMethod digestMethod)
        {
            using (var alg = digestMethod.GetHashAlgorithm())
            {
                return alg.ComputeHash(value);
            }
        }

        #endregion
    }
}
