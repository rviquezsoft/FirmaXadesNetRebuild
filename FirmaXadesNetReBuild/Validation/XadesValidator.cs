﻿


using FirmaXadesNetCore.Signature;
using FirmaXadesNetCore.Utils;
using Microsoft.Xades;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Tsp;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace FirmaXadesNetCore.Validation
{
    class XadesValidator
    {
        #region Public methods

        public ValidationResult Validate(SignatureDocument sigDocument)
        {
            /* Los elementos que se validan son:
             * 
             * 1. Las huellas de las referencias de la firma.
             * 2. Se comprueba la huella del elemento SignedInfo y se verifica la firma con la clave pública del certificado.
             * 3. Si la firma contiene un sello de tiempo se comprueba que la huella de la firma coincide con la del sello de tiempo.
             * 
             * La validación de perfiles -C, -X, -XL y -A esta fuera del ámbito de este proyecto.
             */
            
            ValidationResult result = new ValidationResult();
                       
            try
            {                
                // Verifica las huellas de las referencias y la firma
                sigDocument.XadesSignature.CheckXmldsigSignature();
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.Message = "La verificación de la firma no ha sido satisfactoria";

                return result;
            }
            
            if (sigDocument.XadesSignature.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection.Count > 0)
            {
                // Se comprueba el sello de tiempo

                TimeStamp timeStamp = sigDocument.XadesSignature.UnsignedProperties.UnsignedSignatureProperties.SignatureTimeStampCollection[0];
                TimeStampToken token = new TimeStampToken(new CmsSignedData(timeStamp.EncapsulatedTimeStamp.PkiData));

                byte[] tsHashValue = token.TimeStampInfo.GetMessageImprintDigest();
                Crypto.DigestMethod tsDigestMethod = Crypto.DigestMethod.GetByOid(token.TimeStampInfo.HashAlgorithm.ObjectID.Id);

                System.Security.Cryptography.Xml.Transform transform = null;

                if (timeStamp.CanonicalizationMethod != null)
                {
                    transform = CryptoConfig.CreateFromName(timeStamp.CanonicalizationMethod.Algorithm) as System.Security.Cryptography.Xml.Transform;
                }
                else
                {
                    transform = new XmlDsigC14NTransform();
                }

                ArrayList signatureValueElementXpaths = new ArrayList();
                signatureValueElementXpaths.Add("ds:SignatureValue");
                byte[] signatureValueHash = DigestUtil.ComputeHashValue(XMLUtil.ComputeValueOfElementList(sigDocument.XadesSignature, signatureValueElementXpaths, transform), tsDigestMethod);

                if (!Arrays.AreEqual(tsHashValue, signatureValueHash))
                {
                    result.IsValid = false;
                    result.Message = "La huella del sello de tiempo no se corresponde con la calculada";

                    return result;
                }
            }

            result.IsValid = true;
            result.Message = "Verificación de la firma satisfactoria";

            return result;
        }

        #endregion
    }
}
