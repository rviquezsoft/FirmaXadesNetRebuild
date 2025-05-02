

using FirmaXadesNetCore.Signature;
using FirmaXadesNetCore.Upgraders.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Upgraders
{
    interface IXadesUpgrader
    {
        void Upgrade(SignatureDocument signatureDocument, UpgradeParameters parameters);        
    }
}
