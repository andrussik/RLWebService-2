using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServerClient.TokenHandlers
{
    public class RiksTokenHandler : DelegatingHandler
    {
        private readonly IIdentityServerClient _identityServerClient;
        private const string AUTHENTICATION_SCHEME = "Bearer";

        public RiksTokenHandler(
            IIdentityServerClient identityServerClient)
        {
            _identityServerClient = identityServerClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            // use existing token
            var accessToken = _identityServerClient.GetRiksAccessToken();
            
            // set the bearer token to the outgoing request
            request.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, accessToken);
            
            var response = await base.SendAsync(request, cancellationToken);

            // request new token on 401
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // request the access token
                accessToken = await _identityServerClient.RequestRiksTokenAsync();

                // set the bearer token to the outgoing request
                request.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}