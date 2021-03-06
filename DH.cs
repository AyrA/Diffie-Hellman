﻿using System;
using System.Numerics;

namespace DHKE
{
    /// <summary>
    /// Provides an easy to understand DH implementation with real DH numbers
    /// </summary>
    public class DH
    {
        /// <summary>
        /// Gets the secret number that is not to be shared with anyone
        /// </summary>
        public BigInteger Secret { get; private set; }
        /// <summary>
        /// Gets the public number that is to be shared with your communication partner
        /// </summary>
        public BigInteger Public { get; private set; }
        /// <summary>
        /// Gets the shared secret after <see cref="GetSharedSecret(BigInteger)"/> has been called
        /// </summary>
        public BigInteger Shared { get; private set; }

        /// <summary>
        /// Gets the public DH parameters used for secret and public key generation
        /// </summary>
        public DHPrime PublicDHParams { get; private set; }

        /// <summary>
        /// Initializes this instance with a randomly generated secret and the smallest safe DH prime
        /// </summary>
        public DH() : this(null, DHConstants.Safe)
        {
            //Random new secret and smallest safe DH primes
        }

        /// <summary>
        /// Initializes this instance with a randomly generated secret and the supplied DH primes
        /// </summary>
        /// <param name="PublicPrimes">Public DH primes</param>
        public DH(DHPrime PublicPrimes) : this(null, PublicPrimes)
        {
            //Random new secret and user supplied DH primes
        }

        /// <summary>
        /// Initializes this instance with an existing secret
        /// </summary>
        /// <param name="ExistingSecret">Existing DH secret</param>
        /// <param name="PublicPrimes">Public DH primes</param>
        /// <remarks>
        /// Secrets should not be reused.
        /// The only reason to use this type of the constructor is to use a secret that was generated by other means.
        /// The secret MUST be between the low and high DH prime numbers.
        /// </remarks>
        public DH(byte[] ExistingSecret, DHPrime PublicPrimes)
        {
            if (PublicPrimes == null)
            {
                throw new ArgumentNullException(nameof(PublicPrimes));
            }
            PublicDHParams = PublicPrimes;
            Secret = Public = Shared = BigInteger.MinusOne;
            if (ExistingSecret == null)
            {
                Secret = PublicPrimes.GenerateSecret();
            }
            else
            {
                Secret = new BigInteger(ExistingSecret);
                if (Secret <= PublicDHParams.Low || Secret >= PublicDHParams.High)
                {
                    throw new ArgumentException($"Existing secret must be between {PublicDHParams.Low} and {PublicDHParams.High} exclusive");
                }
            }
            Public = BigInteger.ModPow(PublicDHParams.Low, Secret, PublicDHParams.High);
        }

        /// <summary>
        /// Computes the shared secret 
        /// </summary>
        /// <param name="RemotePublic">Public number received from the other party</param>
        /// <returns>Shared secret</returns>
        /// <remarks>The last result is also available as <see cref="Shared"/></remarks>
        public BigInteger GetSharedSecret(BigInteger RemotePublic)
        {
            return Shared = BigInteger.ModPow(RemotePublic, Secret, PublicDHParams.High);
        }
    }
}
