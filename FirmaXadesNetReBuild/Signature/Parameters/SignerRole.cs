

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public class SignerRole
    {
        #region Private variables

        private List<X509Certificate> _certifiedRoles;
        private List<string> _claimedRoles;

        #endregion


        #region Public properties

        public List<X509Certificate> CertifiedRoles
        {
            get
            {
                return _certifiedRoles;
            }
        }

        public List<string> ClaimedRoles
        {
            get
            {
                return _claimedRoles;
            }
        }

        #endregion

        #region Constructors

        public SignerRole()
        {
            _certifiedRoles = new List<X509Certificate>();
            _claimedRoles = new List<string>();
        }

        #endregion
    }
}
