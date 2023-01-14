using System;
using System.Net.Http.Headers;
using LojaWebApp.MVC.Extensions;

namespace LojaWebApp.MVC.Services.Handlers
{
	public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
	{
		private readonly IUser _user;

		public HttpClientAuthorizationDelegatingHandler(IUser user)
		{
			_user = user;
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var authorationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

			if (!string.IsNullOrEmpty(authorationHeader))
			{
				request.Headers.Add("Authorization", new List<string>() { authorationHeader });
			}

			var token = _user.ObterUserToken();

			if (token != null)
			{
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			return base.SendAsync(request, cancellationToken);
		}

	}
}

