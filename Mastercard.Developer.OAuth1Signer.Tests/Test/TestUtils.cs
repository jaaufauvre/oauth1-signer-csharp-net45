﻿using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Mastercard.Developer.OAuth1Signer.Core.Utils;

namespace Mastercard.Developer.OAuth1Signer.Tests.Test
{
    internal static class TestUtils
    {
        internal static RSACryptoServiceProvider GetTestPrivateKey() => SecurityUtils.LoadPrivateKey(
            "./_Resources/test_key_container.p12", 
            "mykeyalias", 
            "Password1",
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable // https://github.com/dotnet/corefx/issues/14745
        );
    }
}
