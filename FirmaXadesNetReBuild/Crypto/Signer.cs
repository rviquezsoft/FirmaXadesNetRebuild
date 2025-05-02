

using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace FirmaXadesNetCore.Crypto
{
    public class Signer : IDisposable
    {
        #region Private variables

        private bool _disposeCryptoProvider;
        private X509Certificate2 _signingCertificate;
        private AsymmetricAlgorithm _signingKey;

        #endregion

        #region Public properties

        public X509Certificate2 Certificate
        {
            get
            {
                return _signingCertificate;
            }
        }

        public AsymmetricAlgorithm SigningKey
        {
            get
            {
                return _signingKey;
            }
        }

        #endregion

        #region Constructors

        public Signer(X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException("certificate");
            }
            
            if (!certificate.HasPrivateKey)
            {
                throw new Exception("El certificado no contiene ninguna clave privada");
            }

            _signingCertificate = certificate;

            SetSigningKey(_signingCertificate);
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            if (_disposeCryptoProvider && _signingKey != null)
            {
                _signingKey.Dispose();
            }
        }

        #endregion

        #region Private methods

        private void SetSigningKey(X509Certificate2 certificate)
        {
            var key = certificate.GetRSAPrivateKey();
            _signingKey = key;
            _disposeCryptoProvider = false;
        }

        #endregion
    }
}
