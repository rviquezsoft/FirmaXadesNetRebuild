

using FirmaXadesNetCore.Signature;
using FirmaXadesNetCore.Upgraders.Parameters;
using FirmaXadesNetCore.Utils;
using Microsoft.Xades;
using System;
using System.Collections;
using System.Security.Cryptography.Xml;

namespace FirmaXadesNetCore.Upgraders
{
    class XadesTUpgrader : IXadesUpgrader
    {

        #region Public methods

        public void Upgrade(SignatureDocument signatureDocument, UpgradeParameters parameters)
        {
            TimeStamp signatureTimeStamp;
            ArrayList signatureValueElementXpaths;
            byte[] signatureValueHash;
            UnsignedProperties unsignedProperties = signatureDocument.XadesSignature.UnsignedProperties;

            try
            {
                if (unsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Count > 0)
                {
                    throw new Exception("La firma ya contiene un sello de tiempo");
                }

                XmlDsigExcC14NTransform excTransform = new XmlDsigExcC14NTransform();

                signatureValueElementXpaths = new ArrayList();
                signatureValueElementXpaths.Add("ds:SignatureValue");
                signatureValueHash = DigestUtil.ComputeHashValue(XMLUtil.ComputeValueOfElementList(signatureDocument.XadesSignature, signatureValueElementXpaths, excTransform), parameters.DigestMethod);

                byte[] tsa = parameters.TimeStampClient.GetTimeStamp(signatureValueHash, parameters.DigestMethod, true);

                signatureTimeStamp = new TimeStamp("SignatureTimeStamp");
                signatureTimeStamp.Id = "SignatureTimeStamp-" + signatureDocument.XadesSignature.Signature.Id;
                signatureTimeStamp.CanonicalizationMethod = new CanonicalizationMethod();
                signatureTimeStamp.CanonicalizationMethod.Algorithm = excTransform.Algorithm;
                signatureTimeStamp.EncapsulatedTimeStamp.PkiData = tsa;
                signatureTimeStamp.EncapsulatedTimeStamp.Id = "SignatureTimeStamp-" + Guid.NewGuid().ToString();

                unsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Add(signatureTimeStamp);

                signatureDocument.XadesSignature.UnsignedProperties = unsignedProperties;

                signatureDocument.UpdateDocument();
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al insertar el sellado de tiempo.", ex);
            }
        }

        #endregion
    }
}
