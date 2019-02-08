using System;
using Mastercard.Developer.OAuth1Signer.RestSharp.Authenticators;
using Mastercard.Developer.OAuth1Signer.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Mastercard.Developer.OAuth1Signer.Tests.Authenticators
{
    [TestClass]
    public class RestSharpOAuth1AuthenticatorTest
    {
        [TestMethod]
        public void TestAuthenticate_ShouldSignRequest()
        {
            // GIVEN
            var signingKey = TestUtils.GetTestPrivateKey();
            const string consumerKey = "Some key";
            var baseUri = new Uri("https://api.mastercard.com/");
            var request = new RestRequest
            {
                Method = Method.GET,
                Resource = "/service"
            };

            // WHEN
            var instanceUnderTest = new RestSharpOAuth1Authenticator(consumerKey, signingKey, baseUri);
            instanceUnderTest.Authenticate(null, request);

            // THEN
            Parameter authorizationHeader = request.Parameters.Find(p => p.Name.Equals("Authorization"));
            Assert.IsNotNull(authorizationHeader);
            Assert.IsNotNull(authorizationHeader.Value);
        }
    }
}
