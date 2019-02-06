﻿using System;
using System.Security.Cryptography;
using System.Text;
// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace Mastercard.Developer.OAuth1Signer.Core.Signers
{
    public abstract class BaseSigner
    {
        protected RSACryptoServiceProvider SigningKey { get; }
        protected string ConsumerKey { get; }
        protected Encoding Encoding { get; }

        protected BaseSigner(string consumerKey, RSACryptoServiceProvider signingKey, Encoding encoding)
        {
            ConsumerKey = consumerKey ?? throw new ArgumentNullException(nameof(consumerKey));
            SigningKey = signingKey ?? throw new ArgumentNullException(nameof(signingKey));
            Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        }

        protected BaseSigner(string consumerKey, RSACryptoServiceProvider signingKey) : this(consumerKey, signingKey, Encoding.UTF8)
        {
        }
    }
}
