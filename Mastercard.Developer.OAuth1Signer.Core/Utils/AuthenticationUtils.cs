using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
// ReSharper disable InconsistentNaming

namespace Mastercard.Developer.OAuth1Signer.Core.Utils
{
    /// <summary>
    /// Utility class.
    /// </summary>
    public static class AuthenticationUtils
    {
        /// <summary>
        /// Load a RSACryptoServiceProvider object out of a PKCS#12 container.
        /// </summary>
        public static RSACryptoServiceProvider LoadSigningKey(string pkcs12KeyFilePath, string signingKeyAlias, string signingKeyPassword,
            X509KeyStorageFlags keyStorageFlags = X509KeyStorageFlags.Exportable)
        {
            if (pkcs12KeyFilePath == null) throw new ArgumentNullException(nameof(pkcs12KeyFilePath));
            var signingCertificate = new X509Certificate2(pkcs12KeyFilePath, signingKeyPassword, keyStorageFlags);
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)signingCertificate.PrivateKey;
            byte[] privateKeyBlob = rsa.ExportCspBlob(true);
            var key = new RSACryptoServiceProvider();
            key.ImportCspBlob(privateKeyBlob);
            return key;
        }
    }
}
