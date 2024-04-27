using Garnet.client;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Poc.Garnet.Dotnet8.Map
{
    public static class DataMap
    {
        public static GarnetClient GetConnectionWithGarnet()
            => new(
                GarnetSettings.Address,
                int.Parse(GarnetSettings.Port),
                GetSslOpts(),
                GarnetSettings.AuthUserName,
                GarnetSettings.AuthPassword,
                int.Parse(GarnetSettings.DefaultSendPageSize),
                int.Parse(GarnetSettings.DefaultMaxOutstandingTasks),
                TimeSpan.FromMilliseconds(int.Parse(GarnetSettings.Timeout)).Milliseconds);

        public static SslClientAuthenticationOptions GetSslOpts(bool useTLS = false)
            => useTLS ? new()
            {
                ClientCertificates = [new X509Certificate2(GarnetSettings.CertificateName, GarnetSettings.CertificatePassword)],
                TargetHost = "GarnetTest",
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            } : null;
    }
}
