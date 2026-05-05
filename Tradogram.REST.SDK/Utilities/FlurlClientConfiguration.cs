using Flurl.Http;

namespace Tradogram.REST.SDK.Utilities;

public class FlurlClientConfiguration()
{
    /// <summary>
    /// Configures the FlurlClient with the specified base URL, redirect behavior, and timeout settings.
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="enableRedirect"></param>
    /// <param name="timeoutSecs"></param>
    /// <returns></returns>
    public FlurlClient CreateFlurlClient(string baseUrl, bool enableRedirect = false, int timeoutSecs = 30)
    {
        var client = new FlurlClient(baseUrl);
        client.WithTimeout(TimeSpan.FromSeconds(timeoutSecs));
        client.WithAutoRedirect(enableRedirect);

        return client;
    }
}
