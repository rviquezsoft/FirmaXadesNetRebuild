

using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Utils
{
    public static class CertUtil
    {
        #region Public methods

        public static X509Chain GetCertChain(X509Certificate2 certificate, X509Certificate2[] certificates = null)
        {
            X509Chain chain = new X509Chain();

            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreWrongUsage;

            if (certificates != null)
            {
                chain.ChainPolicy.ExtraStore.AddRange(certificates);
            }

            if (!chain.Build(certificate))
            {
                throw new Exception("Can not build certification chain");
            }

            return chain;
        }

        /// <summary>
        /// Validates certificate chain, with manual validation of the rot certificate (passed as parameter).
        /// Caller must validate that the root is correct (i.e. look it up in a database).
        /// </summary>
        /// <param name="certificateToValidate">The certificate to be validated.</param>
        /// <param name="rootCertificate">The certificate chain should terminate in this root certificate.</param>
        /// <param name="revocationChecks">Specifies what kind of revocation check should be performed. None by default.</param>
        /// <returns></returns>
        public static bool VerifyCertificate(X509Certificate2 certificateToValidate, X509Certificate2 rootCertificate, X509RevocationMode revocationChecks = X509RevocationMode.NoCheck)
        {
            X509Chain chain = new X509Chain();
            chain.ChainPolicy.RevocationMode = revocationChecks;
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            chain.ChainPolicy.VerificationTime = DateTime.Now;
            chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);

            // This part is very important. You're adding your known root here.
            // It doesn't have to be in the computer store at all. Neither certificates do.
            chain.ChainPolicy.ExtraStore.Add(rootCertificate);

            bool isChainValid = chain.Build(certificateToValidate);

            if (!isChainValid)
            {
                string[] errors = chain.ChainStatus
                    .Select(x => String.Format("{0} ({1})", x.StatusInformation.Trim(), x.Status))
                    .ToArray();
                string certificateErrorsString = "Unknown errors.";

                if (errors != null && errors.Length > 0)
                {
                    certificateErrorsString = String.Join(", ", errors);
                }

                throw new Exception("Trust chain did not complete to the known authority anchor. Errors: " + certificateErrorsString);
            }

            // This piece makes sure it actually matches your known root
            if (!chain.ChainElements
                .Cast<X509ChainElement>()
                .Any(x => x.Certificate.Thumbprint == rootCertificate.Thumbprint))
            {
                throw new Exception("Trust chain did not complete to the known authority anchor. Thumbprints did not match.");
            }
            return true;
        }
        #endregion


    }
}
