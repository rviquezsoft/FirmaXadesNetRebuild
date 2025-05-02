

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public class SignatureCommitmentType
    {
        #region Private variables

        private string _uri;

        #endregion

        #region Public properties

        public static SignatureCommitmentType ProofOfOrigin = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfOrigin");
        public static SignatureCommitmentType ProofOfReceipt = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfReceipt");
        public static SignatureCommitmentType ProofOfDelivery = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfDelivery");
        public static SignatureCommitmentType ProofOfSender = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfSender");
        public static SignatureCommitmentType ProofOfApproval = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfApproval");
        public static SignatureCommitmentType ProofOfCreation = new SignatureCommitmentType("http://uri.etsi.org/01903/v1.2.2#ProofOfCreation");

        public string URI
        {
            get
            {
                return _uri;
            }
        }

        #endregion

        #region Constructors

        public SignatureCommitmentType(string uri)
        {
            _uri = uri;
        }

        #endregion
    }
}
