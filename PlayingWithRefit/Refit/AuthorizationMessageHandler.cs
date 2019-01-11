﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRefit.Refit
{
  public class AuthorizationMessageHandler : DelegatingHandler
  {
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancelToken)
    {
      HttpRequestHeaders headers = request.Headers;

      // If you have the following attribute in your interface, which you defined,
      // authorization header will be "Bearer", not null.
      // [Headers("Authorization: Bearer")]
      AuthenticationHeaderValue authHeader = headers.Authorization;

      if (authHeader != null)
        headers.Authorization = new AuthenticationHeaderValue(authHeader.Scheme, "TestToken");

      //headers.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, "TestToken");

      return await base.SendAsync(request, cancelToken);
    }
  }
}
