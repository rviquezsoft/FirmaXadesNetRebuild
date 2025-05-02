

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public class SignatureXPathExpression
    {
        #region Private variables

        private Dictionary<string, string> _namespaces;

        #endregion

        #region Public properties

        public string XPathExpression { get; set; }

        public Dictionary<string, string> Namespaces
        {
            get
            {
                return _namespaces;
            }
        }

        #endregion

        #region Constructors

        public SignatureXPathExpression()
        {
            _namespaces = new Dictionary<string, string>();
        }

        #endregion
    }
}
