using System;
using Mastercard.Developer.OAuth1Signer.RestSharp.Signers;
using Mastercard.Developer.OAuth1Signer.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Mastercard.Developer.OAuth1Signer.Tests.Signers
{
    [TestClass]
    public class RestSharpSignerTest
    {
        [TestMethod]
        public void TestSign_ShouldAddOAuth1HeaderToRequest()
        {
            // GIVEN
            var signingKey = TestUtils.GetTestPrivateKey();
            const string consumerKey = "Some key";
            var baseUri = new Uri("https://api.mastercard.com/");
            var request = new RestRequest
            {
                Method = Method.POST,
                Resource = "/service"
            };
            request.AddJsonBody("{\"foo\":\"bår\"}"); // "application/json; charset=utf-8"

            // WHEN
            var instanceUnderTest = new RestSharpSigner(consumerKey, signingKey);
            instanceUnderTest.Sign(baseUri, request);

            // THEN
            var authorizationHeader = request.Parameters.Find(p => p.Name.Equals("Authorization"));
            var authorizationHeaderValue = authorizationHeader.Value as string;
            Assert.IsNotNull(authorizationHeaderValue);
        }
    }
}
