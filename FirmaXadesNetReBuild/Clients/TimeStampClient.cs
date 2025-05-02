

using FirmaXadesNetCore.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tsp;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace FirmaXadesNetCore.Clients
{
    public class TimeStampClient : ITimeStampClient
    {
        #region Private variables
        private string _url;
        private string _user;
        private string _password;
        #endregion

        #region Constructors

        public TimeStampClient(string url)
        {
            _url = url;
        }

        public TimeStampClient(string url, string user, string password)
            : this(url)
        {
            _user = user;
            _password = password;
        }


        #endregion

        #region Public methods

        /// <summary>
        /// Realiza la petición de sellado del hash que se pasa como parametro y devuelve la
        /// respuesta del servidor.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="digestMethod"></param>
        /// <param name="certReq"></param>
        /// <returns></returns>
        public byte[] GetTimeStamp(byte[] hash, DigestMethod digestMethod, bool certReq)
        {
            TimeStampRequestGenerator tsrq = new TimeStampRequestGenerator();
            tsrq.SetCertReq(certReq);

            BigInteger nonce = BigInteger.ValueOf(DateTime.Now.Ticks);

            TimeStampRequest tsr = tsrq.Generate(digestMethod.Oid, hash, nonce);
            byte[] data = tsr.GetEncoded();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url);
            req.Method = "POST";
            req.ContentType = "application/timestamp-query";
            req.ContentLength = data.Length;

            if (!string.IsNullOrEmpty(_user) && !string.IsNullOrEmpty(_password))
            {
                string auth = string.Format("{0}:{1}", _user, _password);
                req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(auth), Base64FormattingOptions.None);
            }

            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("El servidor ha devuelto una respuesta no válida");
            }
            else
            {
                Stream resStream = new BufferedStream(res.GetResponseStream());
                TimeStampResponse tsRes = new TimeStampResponse(resStream);
                resStream.Close();

                tsRes.Validate(tsr);

                if (tsRes.TimeStampToken == null)
                {
                    throw new Exception("El servidor no ha devuelto ningún sello de tiempo");
                }

                return tsRes.TimeStampToken.GetEncoded();
            }
        }

        #endregion
    }
}
