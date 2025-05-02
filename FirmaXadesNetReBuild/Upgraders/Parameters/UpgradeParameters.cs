

using FirmaXadesNetCore.Clients;
using FirmaXadesNetCore.Crypto;
using Org.BouncyCastle.X509;
using System.Collections.Generic;
using System.IO;

namespace FirmaXadesNetCore.Upgraders.Parameters
{
    public class UpgradeParameters
    {
        #region Private variables

        private List<OcspServer> _ocspServers;

        private List<X509Crl> _crls;

        private DigestMethod _digestMethod;

        private ITimeStampClient _timeStampClient;

        private X509CrlParser _crlParser;

        private DigestMethod _defaultDigestMethod = DigestMethod.SHA1;

        private bool _getOcspUrlFromCertificate;

        #endregion

        #region Public properties

        public List<OcspServer> OCSPServers
        {
            get
            {
                return _ocspServers;
            }
        }

        public IEnumerable<X509Crl> CRL
        {
            get
            {
                return _crls;
            }
        }

        public DigestMethod DigestMethod
        {
            get
            {
                return _digestMethod;
            }

            set
            {
                _digestMethod = value;
            }
        }

        public ITimeStampClient TimeStampClient
        {
            get
            {
                return _timeStampClient;
            }

            set
            {
                _timeStampClient = value;
            }
        }

        public bool GetOcspUrlFromCertificate
        {
            get
            {
                return _getOcspUrlFromCertificate;
            }

            set
            {
                _getOcspUrlFromCertificate = value;
            }
        }

        #endregion

        #region Constructors

        public UpgradeParameters()
        {
            _ocspServers = new List<OcspServer>();
            _crls = new List<X509Crl>();
            _digestMethod = _defaultDigestMethod;
            _crlParser = new X509CrlParser();
            _getOcspUrlFromCertificate = true;
        }

        #endregion

        #region Public methods

        public void AddCRL(Stream stream)
        {
            var x509crl = _crlParser.ReadCrl(stream);

            _crls.Add(x509crl);
        }

        public void ClearCRL()
        {
            _crls.Clear();
        }

        #endregion
    }
}
