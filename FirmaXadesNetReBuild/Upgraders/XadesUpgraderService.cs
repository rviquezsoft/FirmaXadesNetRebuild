

using FirmaXadesNetCore.Signature;
using FirmaXadesNetCore.Upgraders.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaXadesNetCore.Upgraders
{
    public enum SignatureFormat
    {
        XAdES_T,
        XAdES_XL
    }

    public class XadesUpgraderService
    {
        #region Public methods

        public void Upgrade(SignatureDocument sigDocument, SignatureFormat toFormat, UpgradeParameters parameters)
        {
            XadesTUpgrader xadesTUpgrader = null;
            XadesXLUpgrader xadesXLUpgrader = null;

            SignatureDocument.CheckSignatureDocument(sigDocument);

            if (toFormat == SignatureFormat.XAdES_T)
            {
                xadesTUpgrader = new XadesTUpgrader();
                xadesTUpgrader.Upgrade(sigDocument, parameters);
            }
            else
            {
                if (sigDocument.XadesSignature.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Count == 0)
                {
                    xadesTUpgrader = new XadesTUpgrader();
                    xadesTUpgrader.Upgrade(sigDocument, parameters);
                }

                xadesXLUpgrader = new XadesXLUpgrader();
                xadesXLUpgrader.Upgrade(sigDocument, parameters);
            }
        }

        #endregion
    }
}
