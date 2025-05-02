

using FirmaXadesNetCore.Crypto;
using System;
using System.Collections.Generic;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public enum SignaturePackaging
    {
        INTERNALLY_DETACHED,
        HASH_INTERNALLY_DETACHED,
        EXTERNALLY_DETACHED,
        ENVELOPED,
        ENVELOPING
    }
   
    public class SignatureParameters
    {
        #region Private variables

        private SignatureMethod _defaultSignatureMethod = SignatureMethod.RSAwithSHA256;
        private DigestMethod _defaultDigestMethod = DigestMethod.SHA256;

        #endregion

        #region Public properties

        public Signer Signer { get; set; }

        public SignatureMethod SignatureMethod { get; set; }

        public DigestMethod DigestMethod { get; set; }

        public DateTime? SigningDate { get; set; }

        public SignerRole SignerRole { get; set; }

        public List<SignatureCommitment> SignatureCommitments { get; private set; }

        public SignatureProductionPlace SignatureProductionPlace { get; set; }

        public List<SignatureXPathExpression> XPathTransformations { get; private set; }

        public SignaturePolicyInfo SignaturePolicyInfo { get; set; }

        public SignatureXPathExpression SignatureDestination { get; set; }

        public SignaturePackaging SignaturePackaging { get; set; }

        public DataFormat DataFormat { get; set; }

        public string ElementIdToSign { get; set; }

        public string ExternalContentUri { get; set; }

        #endregion

        #region Constructors

        public SignatureParameters()
        {
            this.XPathTransformations = new List<SignatureXPathExpression>();
            this.SignatureCommitments = new List<SignatureCommitment>();
            this.SignatureMethod = _defaultSignatureMethod;
            this.DigestMethod = _defaultDigestMethod;
        }

        #endregion
    }
}
