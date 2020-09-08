﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace DHKE
{
    /// <summary>
    /// Public DH primes. Anyone on the planet may see and use these multiple times
    /// </summary>
    /// <remarks>Generated using OpenSSL 1.1.1g</remarks>
    public static class DHConstants
    {
        /// <summary>
        /// Represents the lowest DH length that is considered safe to use.
        /// </summary>
        public const int MIN_SAFE = 2048;

        /// <summary>
        /// List of DH primes with their respective length in bits as key
        /// </summary>
        public static readonly Dictionary<int, DHPrime> Primes;

        /// <summary>
        /// Largest DH prime in the list
        /// </summary>
        public static DHPrime Largest
        {
            get
            {
                return Primes[Primes.Max(m => m.Key)];
            }
        }

        /// <summary>
        /// Gets the smallest DH prime that is considered safe to use by modern standards
        /// </summary>
        public static DHPrime Safe
        {
            get
            {
                return Primes[MIN_SAFE];
            }
        }

        /// <summary>
        /// Static initializer to preload the class with a few good DH primes
        /// </summary>
        static DHConstants()
        {
            byte[] low = new byte[] { 2 };
            Primes = new Dictionary<int, DHPrime>();

            Stopwatch SW = Stopwatch.StartNew();
            #region Long DH Prime Initialization
            //All numbers created using OpenSSL 1.1.1g
            Primes.Add(1024 * 1, new DHPrime(new byte[] {
                0xC8, 0x1E, 0x1C, 0xA2, 0x52, 0xE4, 0x14, 0xF0, 0x37, 0x51,
                0xA7, 0xE1, 0x0A, 0xCB, 0x1D, 0xA7, 0xCC, 0xA1, 0xEB, 0x1F,
                0x2A, 0x6C, 0x1F, 0x35, 0x4C, 0xDF, 0x70, 0xEF, 0xB0, 0xC9,
                0xA0, 0xBD, 0x19, 0x24, 0xED, 0xFA, 0xF1, 0xFE, 0x4A, 0xE8,
                0x68, 0x84, 0xAB, 0x08, 0x1F, 0x20, 0x0B, 0xDB, 0x58, 0x7A,
                0xBD, 0x30, 0x32, 0x84, 0x5A, 0xDA, 0xDD, 0x31, 0xC1, 0x1E,
                0x0F, 0xE6, 0x4B, 0x71, 0xAE, 0x6F, 0x2C, 0x35, 0xBB, 0xFB,
                0x93, 0x36, 0x14, 0x36, 0x29, 0xDD, 0x16, 0xD6, 0x6A, 0x86,
                0x60, 0xA8, 0x07, 0x97, 0xBE, 0x87, 0x0B, 0x37, 0xD3, 0xA2,
                0x1B, 0xA1, 0x03, 0x10, 0xDC, 0x9B, 0x42, 0x9E, 0xB3, 0xE8,
                0xE4, 0x6E, 0x38, 0xB9, 0x4A, 0xCD, 0xE5, 0xFC, 0x0F, 0x24,
                0x2C, 0xDB, 0x89, 0xDE, 0x0A, 0xA1, 0xF2, 0xB7, 0x61, 0x5B,
                0xBB, 0x19, 0x71, 0x8D, 0x24, 0x25, 0x2B, 0xFB
            }, low, false));
            Primes.Add(1024 * 2, new DHPrime(new byte[] {
                0xA1, 0xAD, 0x22, 0xEA, 0xEE, 0xBA, 0x3F, 0xC2, 0xF1, 0x5D,
                0x1E, 0x96, 0x24, 0x88, 0xC2, 0xF0, 0x13, 0x07, 0xE1, 0x07,
                0x07, 0x08, 0x94, 0x16, 0xE4, 0xC3, 0xDC, 0x25, 0xB9, 0xC8,
                0x07, 0x8C, 0x38, 0x00, 0xBD, 0xA3, 0x0A, 0x20, 0xBE, 0xD6,
                0x43, 0x8A, 0x99, 0x56, 0x06, 0x70, 0x03, 0x17, 0x9A, 0x7A,
                0x74, 0x27, 0xFB, 0x1B, 0xBD, 0xD0, 0x8C, 0x0E, 0xD5, 0xD7,
                0xCB, 0x91, 0x3E, 0x8E, 0xA5, 0xE0, 0xB5, 0xFF, 0x12, 0xD3,
                0x39, 0x83, 0x8A, 0x6B, 0xDB, 0x4F, 0xBB, 0x27, 0x0C, 0x9C,
                0x41, 0x3E, 0x0A, 0xC5, 0xE8, 0xA7, 0x1B, 0xE9, 0xCA, 0x95,
                0x95, 0x8A, 0xE9, 0x8E, 0x84, 0xA7, 0xB4, 0xD6, 0xBE, 0x66,
                0x0E, 0x51, 0xDB, 0x58, 0x28, 0xC3, 0x7E, 0xDD, 0x52, 0x5C,
                0xAC, 0xEA, 0xF0, 0x29, 0xD0, 0x82, 0x06, 0x2D, 0x8B, 0x41,
                0x44, 0x11, 0xA3, 0x22, 0xF3, 0x42, 0xDE, 0x8F, 0xE6, 0x74,
                0x2A, 0x62, 0x40, 0x6F, 0xFA, 0x5A, 0x21, 0x5E, 0x45, 0x59,
                0xBF, 0x78, 0x9E, 0xB5, 0x38, 0xF4, 0x67, 0x65, 0x35, 0x6C,
                0x59, 0x31, 0xC1, 0x7C, 0xA2, 0xFA, 0xC1, 0x73, 0xE2, 0x23,
                0xD2, 0xA2, 0x61, 0x24, 0x7F, 0xBD, 0x7A, 0x98, 0xB4, 0xB5,
                0x60, 0xD1, 0xCA, 0x59, 0x1C, 0x35, 0x78, 0x73, 0xB5, 0xB8,
                0xB1, 0xE4, 0x75, 0x34, 0x38, 0x4D, 0x72, 0x68, 0x8F, 0x7E,
                0xCC, 0x30, 0x99, 0x11, 0xA8, 0x7B, 0x42, 0x50, 0x4B, 0x08,
                0xBD, 0xAE, 0x2F, 0xFB, 0xC9, 0x21, 0x30, 0xF5, 0xEA, 0x86,
                0x83, 0x9E, 0x11, 0x0C, 0x87, 0xEA, 0xFA, 0xE4, 0x9B, 0xA1,
                0x86, 0x9A, 0xBA, 0x4F, 0x97, 0x1E, 0x4C, 0xAA, 0x7C, 0x38,
                0x98, 0xB4, 0xF2, 0x93, 0xA5, 0x84, 0x98, 0xB1, 0xF0, 0xA9,
                0x68, 0x28, 0xAA, 0x59, 0x4E, 0x5F, 0x52, 0x16, 0x1A, 0x26,
                0x2A, 0x59, 0x84, 0x98, 0xDB, 0xFB
            }, low, false));
            Primes.Add(1024 * 4, new DHPrime(new byte[] {
                0x8A, 0x79, 0xC8, 0x3C, 0x12, 0x44, 0x2A, 0xE0, 0x00, 0x25,
                0xE5, 0x5C, 0xC7, 0xDA, 0x99, 0x0C, 0xB2, 0xBB, 0x52, 0xE9,
                0x57, 0xF1, 0x3A, 0x8D, 0x82, 0x65, 0x12, 0xE3, 0x58, 0x99,
                0xF4, 0x61, 0xD7, 0x63, 0xE5, 0xA9, 0xA0, 0x78, 0x46, 0xCD,
                0xD1, 0x28, 0xF5, 0x0C, 0xF3, 0x58, 0x7F, 0x82, 0x26, 0x1D,
                0x1C, 0x3D, 0xEE, 0x77, 0x36, 0x51, 0x90, 0xE7, 0xAE, 0xE2,
                0xE1, 0x3F, 0x3C, 0x7B, 0x54, 0x93, 0x3C, 0xD4, 0xCE, 0xB9,
                0x19, 0x67, 0x58, 0xBB, 0x6F, 0xB6, 0x75, 0xB5, 0x7D, 0x71,
                0x3F, 0x0C, 0xCD, 0x92, 0x50, 0x02, 0xE5, 0x41, 0xEC, 0x49,
                0x66, 0x93, 0x17, 0x1A, 0x9E, 0x80, 0x8B, 0x53, 0x65, 0xA0,
                0x01, 0xDD, 0xF9, 0xD7, 0xED, 0xAE, 0x01, 0xE2, 0x5F, 0x17,
                0xF2, 0x60, 0x2C, 0xBF, 0xA1, 0xB9, 0x3F, 0x3D, 0x29, 0x73,
                0xB5, 0x5D, 0x16, 0xBF, 0xB5, 0xBB, 0x5E, 0x3B, 0x7A, 0x0B,
                0x40, 0xD1, 0x79, 0x2E, 0x47, 0x66, 0xE1, 0x80, 0xF9, 0xC2,
                0xCD, 0x74, 0x19, 0x30, 0x39, 0xDD, 0xE6, 0x7C, 0xE4, 0x00,
                0x9A, 0xB6, 0x65, 0x8D, 0x72, 0xCA, 0x78, 0x11, 0xCD, 0xD4,
                0x50, 0xB5, 0x10, 0x50, 0xE7, 0x2F, 0xEF, 0xF1, 0x25, 0xF6,
                0x82, 0x55, 0xEF, 0x31, 0x4B, 0xD5, 0x73, 0xE4, 0x71, 0x36,
                0x5D, 0xA8, 0x6D, 0xD5, 0x87, 0xCD, 0x30, 0xAF, 0xD1, 0xCC,
                0x10, 0x6B, 0x0D, 0xAF, 0xFA, 0xAD, 0x39, 0x97, 0xDE, 0xEA,
                0xDF, 0xA4, 0x7D, 0x22, 0xC0, 0x5C, 0xFD, 0x4D, 0x89, 0x5B,
                0xD4, 0x28, 0xAA, 0x49, 0x05, 0x6D, 0x3C, 0xE4, 0xA4, 0x9C,
                0xCF, 0xFE, 0xB9, 0x35, 0xEA, 0xCD, 0x91, 0xC2, 0xBB, 0xE6,
                0x63, 0x4B, 0x22, 0xA1, 0x88, 0xA8, 0x1C, 0x83, 0xCA, 0xBE,
                0x60, 0x31, 0x3B, 0x30, 0x16, 0x6E, 0x0F, 0xCF, 0xCD, 0x48,
                0xFC, 0xC9, 0xBB, 0x47, 0x62, 0xB4, 0x96, 0xF6, 0x3E, 0x26,
                0xC8, 0x52, 0xEA, 0x25, 0x64, 0x73, 0x59, 0x91, 0xCC, 0x4D,
                0x28, 0xAC, 0x65, 0x80, 0x92, 0x22, 0xA0, 0x30, 0xF4, 0xFF,
                0x32, 0xFE, 0xF7, 0xF8, 0x30, 0x19, 0x69, 0xE9, 0xE7, 0xB0,
                0xE1, 0x35, 0x0E, 0xCB, 0x06, 0x90, 0x42, 0x8E, 0xAD, 0x7B,
                0x08, 0x36, 0x9F, 0x3E, 0x42, 0xF4, 0xE4, 0xCA, 0xDE, 0x23,
                0xF0, 0x29, 0x1D, 0x6D, 0xDF, 0xE0, 0x87, 0x84, 0x90, 0x9C,
                0x5F, 0xB3, 0x5E, 0x40, 0x41, 0x76, 0x47, 0x6D, 0x54, 0x45,
                0x9D, 0x59, 0x17, 0x14, 0x49, 0xFF, 0x01, 0x2A, 0xD4, 0xEE,
                0xBB, 0x3E, 0xB1, 0x12, 0x74, 0x9D, 0x87, 0xDA, 0x46, 0xAC,
                0x12, 0xF1, 0x59, 0xFB, 0xB5, 0x92, 0x24, 0x55, 0x7E, 0x75,
                0x0C, 0xB2, 0x0E, 0x4F, 0x9B, 0x37, 0x20, 0x59, 0xD1, 0x52,
                0x91, 0xA7, 0x17, 0x52, 0xA6, 0x2C, 0xF1, 0x5B, 0xB2, 0x45,
                0xE3, 0x8D, 0x8A, 0x28, 0x1F, 0xD3, 0x4A, 0x92, 0x3A, 0x9B,
                0xB0, 0x56, 0xD7, 0xD5, 0x5B, 0x01, 0xEF, 0x48, 0xD1, 0x02,
                0x63, 0x8F, 0x4D, 0x1E, 0x17, 0x99, 0x7A, 0x7A, 0x95, 0xD4,
                0xEB, 0x10, 0xBB, 0xA4, 0x7C, 0x14, 0x8A, 0x0D, 0x34, 0xBE,
                0xC0, 0x79, 0x42, 0x87, 0xD5, 0x10, 0xF1, 0xC5, 0xE7, 0x1C,
                0x7E, 0xFD, 0x80, 0x62, 0x72, 0x38, 0xFF, 0x83, 0x14, 0xB1,
                0x07, 0x4D, 0xA1, 0x96, 0x3D, 0x5C, 0x9F, 0xA1, 0x9B, 0x26,
                0x14, 0xE6, 0xD6, 0x84, 0xE4, 0x49, 0xB0, 0x30, 0x77, 0xE5,
                0x7A, 0x5B, 0xA4, 0x2A, 0x6C, 0xFE, 0x1C, 0x77, 0x52, 0x90,
                0xCB, 0x7B, 0x81, 0xF3, 0x4F, 0x6B, 0x36, 0x9B, 0x98, 0x13,
                0x11, 0xC7, 0xE7, 0xB9, 0xF9, 0xAC, 0x8F, 0xAF, 0xEF, 0x64,
                0xF3, 0xA6, 0x85, 0xF6, 0x72, 0x6B, 0x5A, 0x71, 0xBC, 0x48,
                0x26, 0x70, 0x5D, 0xAA, 0x82, 0x3D, 0x90, 0x56, 0x69, 0xC6,
                0xBB, 0x1B
            }, low, false));
            Primes.Add(1024 * 8, new DHPrime(new byte[] {
                0xDF, 0xFF, 0x3D, 0x65, 0xCB, 0xBD, 0xA4, 0x82, 0xE1, 0xCF,
                0x12, 0x35, 0x20, 0x0E, 0xF5, 0x8F, 0xF3, 0x96, 0x72, 0x97,
                0x27, 0x18, 0xD6, 0xB8, 0x4D, 0x1B, 0xB5, 0x9C, 0xFB, 0x3D,
                0x39, 0x8B, 0x02, 0x8B, 0xE7, 0xB9, 0xB4, 0xD5, 0x9A, 0xE4,
                0x5D, 0x2D, 0x6F, 0x66, 0x77, 0xF6, 0x1F, 0x56, 0x13, 0xA6,
                0x2D, 0x8C, 0xC9, 0x0C, 0xBA, 0x12, 0xF0, 0xB5, 0x36, 0xFB,
                0x84, 0xC8, 0xCB, 0x71, 0x25, 0xBD, 0x21, 0x16, 0xCE, 0x49,
                0x61, 0xEB, 0x8F, 0xF2, 0xB3, 0xE8, 0xF3, 0xBA, 0x70, 0x8F,
                0x0B, 0x93, 0x64, 0xE2, 0xE5, 0x6A, 0xEC, 0xC7, 0xD5, 0xCB,
                0x41, 0x96, 0x37, 0x46, 0x6F, 0x26, 0x22, 0x3D, 0x0A, 0x14,
                0x66, 0x7C, 0x25, 0x7D, 0x63, 0xF6, 0x0B, 0xC9, 0xF6, 0xC9,
                0x8D, 0xDC, 0xB8, 0xE1, 0xC1, 0xE9, 0x56, 0x03, 0xA5, 0xA0,
                0x59, 0xDA, 0xCC, 0x65, 0xD7, 0x46, 0x25, 0xEE, 0x3A, 0x69,
                0xC1, 0x00, 0x64, 0xEB, 0xC9, 0x21, 0xAE, 0x4C, 0x05, 0x11,
                0x60, 0x57, 0xBB, 0x63, 0x4A, 0x99, 0x90, 0x6E, 0x5B, 0xD8,
                0xA2, 0xD9, 0xEB, 0x26, 0xEB, 0xC7, 0x3C, 0x8E, 0xC8, 0xFB,
                0xF9, 0x84, 0xF3, 0x9E, 0x46, 0xE0, 0x2B, 0x3B, 0xCF, 0x7C,
                0x7B, 0x16, 0x22, 0x3A, 0xBC, 0x69, 0xBD, 0x47, 0x8B, 0xDA,
                0x1A, 0x2A, 0x11, 0xD8, 0xD9, 0x8E, 0xA6, 0x7C, 0x45, 0xE8,
                0x42, 0x77, 0x31, 0xB7, 0x6F, 0x97, 0x44, 0x8E, 0xCE, 0xAB,
                0x1D, 0x27, 0x61, 0xCE, 0xC7, 0xA7, 0x1D, 0xEC, 0xF1, 0x34,
                0xF0, 0x9C, 0x40, 0x02, 0xD8, 0x3C, 0x96, 0x02, 0x2B, 0x2F,
                0x46, 0xBC, 0xFF, 0x49, 0xA1, 0x5E, 0xA1, 0x5E, 0x5D, 0x9C,
                0x36, 0xD4, 0xF6, 0xFD, 0x53, 0xC6, 0xB6, 0xDF, 0xF8, 0x50,
                0xAB, 0xAA, 0x68, 0x1C, 0x08, 0x74, 0x07, 0x15, 0xF5, 0x10,
                0xEC, 0x8C, 0x48, 0x74, 0x10, 0x5B, 0x1E, 0xBD, 0x44, 0x7C,
                0xF2, 0x51, 0x96, 0xD0, 0x9A, 0x1D, 0x5D, 0x44, 0x85, 0x2E,
                0xC1, 0xEC, 0x3A, 0x99, 0x1D, 0xC4, 0x94, 0xCF, 0x1E, 0x00,
                0x27, 0x51, 0x8D, 0xE9, 0xD5, 0x12, 0xAF, 0x05, 0x0E, 0xC9,
                0xFF, 0xA6, 0xA1, 0xF6, 0x8F, 0xBC, 0x2D, 0x5D, 0x41, 0xFC,
                0x96, 0x95, 0xEA, 0x0D, 0xBB, 0x9F, 0xDF, 0x2D, 0x33, 0x35,
                0x27, 0x3F, 0x9C, 0x36, 0xFA, 0xF3, 0xF4, 0x27, 0xDB, 0x9F,
                0x17, 0x5F, 0x29, 0x17, 0x8B, 0xF5, 0x07, 0x20, 0x15, 0x00,
                0x35, 0xC4, 0x84, 0x12, 0x62, 0x30, 0x26, 0x7E, 0x5D, 0x4E,
                0xBE, 0x2C, 0xE0, 0x35, 0x4F, 0x67, 0xB9, 0x46, 0x56, 0xCB,
                0xF7, 0xF3, 0x7C, 0x78, 0x02, 0x40, 0xE9, 0x04, 0x7C, 0xC3,
                0x54, 0x29, 0xD4, 0x9E, 0x72, 0xB3, 0x18, 0x34, 0x01, 0x0E,
                0xFA, 0xBC, 0x4A, 0x87, 0x6D, 0x6B, 0xBC, 0x69, 0x76, 0xD4,
                0xFE, 0x2F, 0x3D, 0x4C, 0x2E, 0x6B, 0x29, 0xEA, 0xAB, 0x55,
                0xD1, 0x0C, 0x39, 0xAB, 0xD9, 0x73, 0x93, 0x63, 0xA8, 0x3C,
                0x7C, 0xC4, 0x8D, 0x9E, 0x4C, 0xF9, 0xB9, 0xE4, 0xE0, 0x9F,
                0x7E, 0x4F, 0xCF, 0x27, 0x4F, 0xD1, 0x80, 0xFA, 0xF1, 0xB9,
                0xFE, 0xE0, 0x88, 0x4F, 0x0E, 0x90, 0x5B, 0x1B, 0xC9, 0x1A,
                0x48, 0x4D, 0x16, 0x72, 0x8F, 0xE8, 0x38, 0x88, 0x09, 0x9B,
                0x0C, 0x46, 0xA2, 0x9F, 0x9A, 0x29, 0xCB, 0xBB, 0xDF, 0x88,
                0xFE, 0xF6, 0x21, 0x1E, 0x9B, 0x26, 0x32, 0xA0, 0x8D, 0x01,
                0x9C, 0x95, 0x73, 0x45, 0x65, 0xA9, 0x1B, 0xF3, 0xFD, 0x49,
                0x06, 0xFE, 0x6C, 0x03, 0x46, 0xEB, 0xFA, 0xD9, 0x67, 0x0E,
                0x9C, 0xC7, 0x97, 0x86, 0x6C, 0x75, 0x95, 0xC8, 0x79, 0x63,
                0x65, 0x69, 0x04, 0x9B, 0xB6, 0x6D, 0x61, 0xDC, 0x04, 0xA0,
                0xCF, 0x6E, 0x7A, 0xF7, 0x0A, 0x47, 0x18, 0x84, 0x38, 0x3D,
                0x7C, 0xA4, 0xB3, 0xBC, 0x7C, 0xF9, 0x66, 0x5D, 0xB7, 0x24,
                0x96, 0x76, 0xD5, 0xC3, 0xAE, 0x43, 0x1B, 0x30, 0xCB, 0x6C,
                0x87, 0xE0, 0x3B, 0x7C, 0xCD, 0xBF, 0xAB, 0x44, 0xE8, 0x30,
                0xBC, 0xFC, 0xF6, 0x9B, 0xFD, 0xED, 0x10, 0xE3, 0x82, 0xEC,
                0xB7, 0x36, 0x0E, 0x0F, 0x33, 0x4D, 0x3D, 0xB2, 0xE3, 0x51,
                0x10, 0xD9, 0xDC, 0xB4, 0x73, 0x4D, 0xE1, 0xDB, 0x06, 0xA8,
                0x4D, 0x29, 0x86, 0x28, 0x47, 0xE5, 0x67, 0x43, 0xEF, 0x85,
                0x0A, 0x4E, 0xD2, 0x80, 0x59, 0xD4, 0x87, 0xB1, 0x4D, 0x64,
                0xC0, 0xBA, 0x28, 0xD1, 0xAF, 0x67, 0xF1, 0xC4, 0x68, 0xD1,
                0x1A, 0xB2, 0xE7, 0x72, 0x22, 0xB5, 0x6F, 0xD8, 0xD0, 0xFA,
                0x8D, 0x62, 0x29, 0xC8, 0x0E, 0x1C, 0x32, 0xB9, 0x77, 0x3F,
                0x0C, 0xB1, 0xCA, 0xA0, 0x6A, 0x9D, 0x05, 0x5C, 0xC6, 0xB3,
                0x62, 0x3C, 0x50, 0x97, 0xB9, 0xCF, 0xAE, 0xF4, 0xEA, 0x30,
                0x7B, 0xEA, 0x26, 0xA9, 0x9A, 0xDA, 0xED, 0x44, 0xEB, 0xD3,
                0xC1, 0x59, 0xA7, 0xA0, 0xFC, 0x61, 0xFD, 0x31, 0xE9, 0xA6,
                0x15, 0x28, 0x6C, 0x52, 0x44, 0x7B, 0xD0, 0x87, 0xCD, 0x78,
                0x16, 0x19, 0x8D, 0x25, 0x03, 0x8B, 0x4D, 0x63, 0x3F, 0xAB,
                0x16, 0x07, 0xBA, 0xA9, 0x3B, 0xE0, 0xF2, 0x7A, 0xE3, 0x9D,
                0x81, 0x93, 0x09, 0x7C, 0x8B, 0x8B, 0x3A, 0xDE, 0x02, 0x2F,
                0xF1, 0xF3, 0x71, 0x50, 0xF1, 0x54, 0x77, 0xA2, 0x7C, 0xD0,
                0x84, 0xA9, 0xD9, 0xEB, 0xAA, 0x4C, 0x1E, 0x74, 0x84, 0x38,
                0x3F, 0x0D, 0xEB, 0x62, 0x83, 0xE4, 0x38, 0x12, 0x3C, 0x1E,
                0xD4, 0xF7, 0x4D, 0x2E, 0xB9, 0x68, 0x6A, 0xDD, 0x59, 0xE6,
                0x46, 0xB6, 0x98, 0xA1, 0x8A, 0xB4, 0x6B, 0x45, 0x2C, 0xF2,
                0xF8, 0x50, 0x2E, 0x16, 0xE2, 0x1A, 0xC4, 0xA0, 0x47, 0xB8,
                0xBD, 0x41, 0xB9, 0x5D, 0xE7, 0x04, 0x8C, 0x5E, 0xA0, 0x6E,
                0xAD, 0x03, 0x40, 0x6E, 0x97, 0x16, 0xA0, 0xF9, 0xA9, 0xAA,
                0x91, 0x95, 0x2F, 0x30, 0x89, 0x6F, 0x2D, 0xDA, 0xCB, 0xC4,
                0x70, 0xDD, 0x3E, 0x09, 0xB8, 0x47, 0xDF, 0x25, 0x2B, 0x93,
                0x06, 0x05, 0xFC, 0xFD, 0x47, 0xDE, 0x4F, 0x73, 0xE3, 0x28,
                0x5F, 0xA8, 0x99, 0x8D, 0xC2, 0xE5, 0xB4, 0x0F, 0x93, 0xD1,
                0x9F, 0x45, 0x8F, 0x52, 0xAA, 0xBA, 0x61, 0xD8, 0x07, 0x0F,
                0xC8, 0xE1, 0xA2, 0x03, 0x17, 0x61, 0x65, 0x7C, 0x9D, 0xCE,
                0x2A, 0x90, 0xAD, 0x53, 0xCB, 0x1C, 0xFB, 0x88, 0xCE, 0xE8,
                0x79, 0x77, 0x8F, 0x72, 0xEE, 0x11, 0x45, 0x0A, 0xE6, 0x60,
                0x4A, 0xC8, 0x89, 0xAB, 0x39, 0x52, 0x64, 0xF4, 0x22, 0x18,
                0xAD, 0xCF, 0x7D, 0x84, 0x40, 0xAB, 0x75, 0xA2, 0xF4, 0x1E,
                0xA1, 0x02, 0x6B, 0xCB, 0xB0, 0xDA, 0x3C, 0x62, 0xF3, 0x1F,
                0xE7, 0xD5, 0xB6, 0xB5, 0x88, 0xD0, 0x40, 0x63, 0x57, 0xC9,
                0x09, 0x47, 0xC4, 0x06, 0x71, 0xD1, 0x54, 0x2A, 0xC8, 0xF8,
                0xF6, 0xC8, 0x60, 0xEC, 0xBB, 0x53, 0x3E, 0xE1, 0xE1, 0x7C,
                0x35, 0xDB, 0xBC, 0x11, 0x0E, 0x9B, 0xCB, 0xA3, 0xC5, 0x9C,
                0xBE, 0x25, 0x05, 0xA7, 0x4F, 0xAB, 0xC4, 0x2D, 0xA4, 0x0F,
                0x38, 0x1E, 0x39, 0x47, 0x12, 0xDC, 0xE4, 0xC9, 0xEC, 0x62,
                0xD8, 0xF9, 0xAB, 0xA3, 0xAB, 0x83, 0x70, 0x86, 0xCC, 0x52,
                0xC6, 0x76, 0xEB, 0xD2, 0x4A, 0x0D, 0x6E, 0x6D, 0xAC, 0xF6,
                0x62, 0xAF, 0x2C, 0x93, 0x5D, 0x4A, 0xB1, 0x66, 0x4A, 0x27,
                0xFF, 0xCE, 0x84, 0x1E, 0xAD, 0x95, 0xEC, 0x56, 0xFA, 0xD0,
                0x65, 0x69, 0x81, 0x47, 0xC1, 0x94, 0xED, 0xA4, 0xAC, 0x5F,
                0x81, 0x6A, 0x86, 0x92, 0x82, 0x9F, 0x04, 0x1F, 0xE4, 0x14,
                0x58, 0x47, 0xD5, 0x82, 0xBE, 0x17, 0x50, 0xF1, 0x35, 0x84,
                0xF5, 0xA8, 0x81, 0x4B
            }, low, false));
            #endregion
            SW.Stop();
            Debug.Print($"Global DH Initialization took {SW.ElapsedMilliseconds} ms");
        }
    }

    /// <summary>
    /// Represents a DH prime pair
    /// </summary>
    public class DHPrime
    {
        /// <summary>
        /// Random Number generator for the <see cref="IsProbablyPrime(BigInteger, int)"/> function
        /// </summary>
        private static readonly Random Gen = new Random();

        /// <summary>
        /// High DH prime
        /// </summary>
        public BigInteger High { get; private set; }
        /// <summary>
        /// Low DH prime
        /// </summary>
        public BigInteger Low { get; private set; }

        /// <summary>
        /// Gets if the primes have been validated using <see cref="IsProbablyPrime(BigInteger, int)"/>
        /// </summary>
        public bool HasBeenValidated { get; private set; }

        /// <summary>
        /// Contains the original supplied high value to the constructor
        /// </summary>
        /// <remarks>This is used in the key generation process.</remarks>
        private readonly byte[] OriginalHigh;

        /// <summary>
        /// Initializes a new DH prime pair
        /// </summary>
        /// <param name="high">High prime</param>
        /// <param name="low">Low prime</param>
        /// <param name="CheckPrime">
        /// Checks if the supplies numbers are likely prime.
        /// Use "false" only if you are certain the numbers are prime.
        /// You can safely set this to "false" if you use numbers generated by common DH implementations,
        /// for example OpenSSL
        /// </param>
        public DHPrime(byte[] high, byte[] low, bool CheckPrime = true)
        {
            //Basic parameter checks
            if (high == null || high.Length == 0)
            {
                throw new ArgumentNullException(nameof(high));
            }
            if (low == null || low.Length == 0)
            {
                throw new ArgumentNullException(nameof(low));
            }
            //Assign public properties
            High = FromHexBytes(high);
            Low = FromHexBytes(low);
            HasBeenValidated = CheckPrime;
            OriginalHigh = (byte[])high.Clone();
            //Basic sanity checks
            if (High.IsEven || High <= Low || High <= 2)
            {
                throw new ArgumentException("High number fails basic conditions");
            }
            if (Low.IsEven && Low != 2)
            {
                throw new ArgumentException("Low number fails basic conditions");
            }
            if (CheckPrime && !IsProbablyPrime(High, 5))
            {
                throw new ArgumentException("High number fails Miller-Rabin prime number test");
            }
            //Low is almost always 2 or 5, making the prime test for these numbers unnecessary
            //This speeds up the program in most cases
            if (Low != 2 && Low != 5 && CheckPrime && !IsProbablyPrime(Low, 5))
            {
                throw new ArgumentException("Low number fails Miller-Rabin prime number test");
            }
        }

        /// <summary>
        /// Generates a secret number from public DH primes
        /// </summary>
        /// <returns>Secret number</returns>
        public BigInteger GenerateSecret()
        {
            using (var RNG = RandomNumberGenerator.Create())
            {
                byte[] Data = new byte[OriginalHigh.Length];
                RNG.GetBytes(Data);
                //A cheap way to ensure your number is smaller than a DH prime
                //is to make the first byte smaller than the other
                //Note that this only works if you treat a byte sequence as unsigned.
                while (Data[0] >= OriginalHigh[0])
                {
                    RNG.GetBytes(Data, 0, 1);
                }
                var Result = FromHexBytes(Data);
                System.Diagnostics.Debug.Assert(Result < High, "Computed number expected to be smaller than high DH prime");
                System.Diagnostics.Debug.Assert(Result > Low, "Computed number expected to be bigger than low DH prime");
                return Result;
            }
        }

        /// <summary>
        /// Converts a hexadecimal number into a BigInteger instance.
        /// The number is always treated as being positive
        /// </summary>
        /// <param name="data">Number</param>
        /// <returns>Number</returns>
        private static BigInteger FromHexBytes(byte[] data)
        {
            var s = string.Concat(data.Select(m => m.ToString("X2")).ToArray());
            return BigInteger.Parse("00" + s, System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        /// Tests if a number is probably a prime
        /// </summary>
        /// <param name="value">Value to test for</param>
        /// <param name="witnesses">Witness count.
        /// Higher numbers reduce the chance of wrong results.
        /// The default of the original implementation is 10,
        /// but it will run for a few seconds on modern hardware.
        /// </param>
        /// <returns>true, if probably prime, false otherwise</returns>
        /// <seealso cref="https://stackoverflow.com/a/33918233/1642933"/>
        public static bool IsProbablyPrime(BigInteger value, int witnesses)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "value must be 0 or bigger");
            }

            if (witnesses <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(witnesses), "Witness count must be 1 or bigger.");
            }

            //Hardcoded tests for 0,1,2
            if (value < 3)
            {
                return value == 2;
            }
            //Don't have to check at all if the number is even
            if (value.IsEven)
            {
                return false;
            }

            BigInteger d = value - 1;
            int s = 0;

            do
            {
                d /= 2;
                s += 1;
            } while (d.IsEven);

            byte[] bytes = new byte[value.ToByteArray().LongLength];
            byte first = value.ToByteArray()[0];
            BigInteger a;

            for (int i = 0; i < witnesses; i++)
            {
                do
                {
                    lock (Gen)
                    {
                        do
                        {
                            //Generate random bytes until it's definitely not larger than the existing number
                            Gen.NextBytes(bytes);
                        }
                        while (bytes[0] > first);
                    }
                    a = BigInteger.Abs(new BigInteger(bytes));
                }
                while (a < 2 || a >= value - 2);

                BigInteger x = BigInteger.ModPow(a, d, value);
                if (x == 1 || x == value - 1)
                {
                    continue;
                }

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, value);

                    if (x == 1)
                    {
                        return false;
                    }
                    if (x == value - 1)
                    {
                        break;
                    }
                }

                if (x != value - 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

