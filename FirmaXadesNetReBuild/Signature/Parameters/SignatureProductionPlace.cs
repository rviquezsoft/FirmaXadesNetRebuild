

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Signature.Parameters
{
    public class SignatureProductionPlace
    {
        #region Public properties

        public string City { get; set; }

        public string StateOrProvince { get; set; }

        public string PostalCode { get; set; }

        public string CountryName { get; set; }

        #endregion
    }
}
