using System;
using System.Security.Cryptography;
using Mastercard.Developer.OAuth1Signer.RestSharp.Signers;
using RestSharp;
#pragma warning disable 1591

namespace Mastercard.Developer.OAuth1Signer.RestSharp.Authenticators
{
    /// <inheritdoc />
    /// <summary>
    /// A RestSharp authenticator for computing and adding an OAuth1 authorization header to HTTP requests.
    /// </summary>
    public class RestSharpOAuth1Authenticator : IAuthenticator
    {
        private Uri BaseUri { get; }
        private RestSharpSigner Signer { get; }

        public RestSharpOAuth1Authenticator(string consumerKey, RSACryptoServiceProvider signingKey, Uri baseUri)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
            Signer = new RestSharpSigner(consumerKey, signingKey);
        }

        public void Authenticate(IRestClient client, IRestRequest request) => Signer.Sign(BaseUri, request);
    }
}
