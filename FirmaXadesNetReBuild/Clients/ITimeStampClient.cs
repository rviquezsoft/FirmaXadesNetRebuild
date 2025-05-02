

using FirmaXadesNetCore.Crypto;
using System;

namespace FirmaXadesNetCore.Clients
{
    public interface ITimeStampClient
    {
        byte[] GetTimeStamp(byte[] hash, DigestMethod digestMethod, bool certReq);
    }
}
