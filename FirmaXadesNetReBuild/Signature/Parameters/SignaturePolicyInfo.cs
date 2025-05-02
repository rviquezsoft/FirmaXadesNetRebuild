

using FirmaXadesNetCore.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public class SignaturePolicyInfo
    {
        #region Private variables

        private DigestMethod _defaultPolicyDigestAlgorithm = DigestMethod.SHA1;

        #endregion

        #region Public properties

        public string PolicyIdentifier { get; set; }

        public string PolicyHash { get; set; }

        public DigestMethod PolicyDigestAlgorithm { get; set; }

        public string PolicyUri { get; set; }

        #endregion

        #region Constructors

        public SignaturePolicyInfo()
        {
            this.PolicyDigestAlgorithm = _defaultPolicyDigestAlgorithm;
        }

        #endregion
    }
}
