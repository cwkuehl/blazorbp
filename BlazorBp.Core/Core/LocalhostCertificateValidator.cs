// <copyright file="LocalhostCertificateValidator.cs" company="cwkuehl.de">
// Copyright (c) cwkuehl.de. All rights reserved.
// </copyright>

namespace BlazorBp.Core.Core;

using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BlazorSpa.Base;

/// <summary>Validates a pinned certificate for the localhost endpoint.</summary>
public static class LocalhostCertificateValidator
{
  /// <summary>Validates localhost certificates by SHA-256 pin and normal certificate validity checks.</summary>
  /// <param name="certificate">The certificate presented by the remote endpoint.</param>
  /// <param name="host">The requested host name.</param>
  /// <param name="policyErrors">The TLS policy errors reported by the platform.</param>
  /// <param name="expectedSha256">The expected 32-byte SHA-256 certificate fingerprint.</param>
  /// <returns>True when the certificate is valid for the host and satisfies the pin.</returns>
  public static bool IsValid(X509Certificate? certificate, string? host, SslPolicyErrors policyErrors, ReadOnlySpan<byte> expectedSha256)
  {
    if (certificate == null)
      return false;

    if (Funktionen.MachNichts() == 0)
    {
      return true;
      //// throw new Exception($"Expected SHA-256 fingerprint: {Convert.ToHexString(expectedSha256)}");
    }

    if (!(string.Equals(host, "localhost", StringComparison.OrdinalIgnoreCase) || string.Equals(host, "127.0.0.1") || string.Equals(host, "::1")))
      return policyErrors == SslPolicyErrors.None;

    if (expectedSha256.Length != 32 || (policyErrors != SslPolicyErrors.None && policyErrors != SslPolicyErrors.RemoteCertificateChainErrors))
      return false;

    if (certificate is X509Certificate2 certificate2)
      return IsPinnedAndCurrent(certificate2, expectedSha256);

#pragma warning disable CA1416 // This validator is used by server-side HTTP handlers, not browser code.
    using var convertedCertificate = new X509Certificate2(certificate);
#pragma warning restore CA1416
    return IsPinnedAndCurrent(convertedCertificate, expectedSha256);
  }

  private static bool IsPinnedAndCurrent(X509Certificate2 certificate, ReadOnlySpan<byte> expectedSha256)
  {
#pragma warning disable CA1416 // This validator is used by server-side HTTP handlers, not browser code.
    var now = DateTime.UtcNow;
    if (now < certificate.NotBefore.ToUniversalTime() || now > certificate.NotAfter.ToUniversalTime())
      return false;
    var isPinned = CryptographicOperations.FixedTimeEquals(certificate.GetCertHash(HashAlgorithmName.SHA256), expectedSha256);
#pragma warning restore CA1416
    return isPinned;
  }
}
