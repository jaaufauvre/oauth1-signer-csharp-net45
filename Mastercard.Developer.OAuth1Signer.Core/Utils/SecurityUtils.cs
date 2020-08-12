using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
// ReSharper disable InconsistentNaming

namespace Mastercard.Developer.OAuth1Signer.Core.Utils
{
    /// <summary>
    /// Utility class.
    /// </summary>
    [Obsolete("Use AuthenticationUtils instead.")]
    public static class SecurityUtils
    {
        /// <summary>
        /// Load a RSACryptoServiceProvider object out of a PKCS#12 container.
        /// </summary>
        public static RSACryptoServiceProvider LoadPrivateKey(string pkcs12KeyFilePath, string signingKeyAlias, string signingKeyPassword, 
            X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.Exportable)
        {
            return AuthenticationUtils.LoadSigningKey(pkcs12KeyFilePath, signingKeyAlias, signingKeyPassword, keyStorageFlags);
        }
    }
}