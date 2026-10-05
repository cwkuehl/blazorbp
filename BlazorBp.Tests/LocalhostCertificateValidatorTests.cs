using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BlazorBp.Core.Core;

namespace BlazorBp.Tests;

public class LocalhostCertificateValidatorTests
{
  [Fact]
  public void AcceptsOnlyThePinnedCurrentLocalhostCertificate()
  {
    using var certificate = CreateLocalhostCertificate(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddDays(1));
    var fingerprint = certificate.GetCertHash(HashAlgorithmName.SHA256);

    Assert.True(LocalhostCertificateValidator.IsValid(
      certificate,
      "localhost",
      SslPolicyErrors.RemoteCertificateChainErrors,
      fingerprint));
    Assert.False(LocalhostCertificateValidator.IsValid(
      certificate,
      "localhost",
      SslPolicyErrors.RemoteCertificateNameMismatch,
      fingerprint));
    Assert.False(LocalhostCertificateValidator.IsValid(
      certificate,
      "localhost",
      SslPolicyErrors.None,
      new byte[32]));
    Assert.True(LocalhostCertificateValidator.IsValid(
      certificate,
      "127.0.0.1",
      SslPolicyErrors.RemoteCertificateChainErrors,
      fingerprint));
    Assert.True(LocalhostCertificateValidator.IsValid(
      certificate,
      "::1",
      SslPolicyErrors.RemoteCertificateChainErrors,
      fingerprint));
  }

  [Fact]
  public void RejectsExpiredLocalhostCertificate()
  {
    using var certificate = CreateLocalhostCertificate(DateTimeOffset.UtcNow.AddDays(-4), DateTimeOffset.UtcNow.AddDays(-2));

    Assert.False(LocalhostCertificateValidator.IsValid(
      certificate,
      "localhost",
      SslPolicyErrors.RemoteCertificateChainErrors,
      certificate.GetCertHash(HashAlgorithmName.SHA256)));
  }

  [Fact]
  public void UsesPlatformValidationForNonLocalhostHosts()
  {
    using var certificate = CreateLocalhostCertificate(DateTimeOffset.UtcNow.AddMinutes(-5), DateTimeOffset.UtcNow.AddDays(1));

    Assert.True(LocalhostCertificateValidator.IsValid(
      certificate,
      "example.com",
      SslPolicyErrors.None,
      new byte[32]));
    Assert.False(LocalhostCertificateValidator.IsValid(
      certificate,
      "example.com",
      SslPolicyErrors.RemoteCertificateChainErrors,
      new byte[32]));
    Assert.False(LocalhostCertificateValidator.IsValid(
      null,
      "example.com",
      SslPolicyErrors.None,
      new byte[32]));
  }

  private static X509Certificate2 CreateLocalhostCertificate(DateTimeOffset notBefore, DateTimeOffset notAfter)
  {
    using var rsa = RSA.Create(2048);
    var request = new CertificateRequest("CN=localhost", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    var subjectAlternativeNames = new SubjectAlternativeNameBuilder();
    subjectAlternativeNames.AddDnsName("localhost");
    request.CertificateExtensions.Add(subjectAlternativeNames.Build());
    return request.CreateSelfSigned(notBefore, notAfter);
  }
}
