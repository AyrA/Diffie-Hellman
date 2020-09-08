Diffie-Hellman Key Exchange
===========================

These files implement the maths of the DH Key Exchange.
They do not use any Windows specific .NET features and are thus usable in .NET core applications.

**This is in no way a complete DHKE implementation!**

This library does the generation and computation of the secret, public and shared values.
How you get the values across to the other communication partner is out of scope.

Features
========

- Various pre-computed DH primes from 1024 to 8192 bits
- Safety checks to prevent usage of bad DH primes
- Cryptographically secure random number generation
- Easy to use

Installation
============

1. Copy the `.cs` files into your project directory
2. add them to the project in your editor if it doesn't adds them automatically
3. Add a reference to `System.Numerics` in your project

Use in security critical applications
=====================================

Care has been taken to implement all security relevant features correctly.
The public DH primes have been generated using OpenSSL and are "safe primes".

The DHPrime class will prevent you from using numbers that are not prime.
Please note that there is a small chance that this check will fail.
You can supply a large number (20 or more) for `DHPrime.IsProbablyPrime` to test a number.
This will take a long time however.

If you want to use your own DH primes, use openSSL.
Run `openssl dhparam -C 2048` and after completion,
copy the byte values into the `DHPrime` constructor.

This library will not stop you from using the shared secret wrong.
Be sure to use appropriate key derivation and hashing algorithms
when using the shared secret for encryption keys.

This implementation has been made to be easy to understand,
not to be fast or efficient.

Usage
=====

	var KE=new DHKE.DH();
	//Send KE.Public to your communication partner
	//Receive the KE.Public value from your communication partner
	var Shared=KE.GetSharedSecret(ValueFromPartner);
	//The Shared value is now identical for both people

Usage considerations
--------------------

When using the library as shown above, it will use a 2048 bit DH prime.
If you need a larger prime, you have to specify it using an alternate DH constructor.

The key exchange only works if both parties use the same DH primes.
One party usually leads in the communication protocol.
It's recommended that this party also transmits the DH prime in use.

DH primes as well as the DH.Public value are considered "public".
You can safely transmit them over an unencrypted connection.
They are not protected against tampering however.
You should sign the values in some way to avoid MITM attacks on your protocol.

**Never reuse the DH.Secret value!**
Create a new DH instance for each new key exchange.

The DH class supports supplying an already existing secret.
This constructor allows reuse of a secret, which you should not do.
It's meant for when you use a different generator for the secret,
for simulation, or when you're replaying recorded events.

DH prime size
-------------

This library comes with 1024, 2048, 4096 and 8192 bit DH primes.
You can also define your own if you're constrained by a protocol.

You should not pick very large primes unless necessary.
Large primes will take considerably longer when calculating the shared secret.
