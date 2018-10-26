using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EBikesShop.Ui.Web.Http
{
    public class HttpRequestBuilder
    {
        private HttpMethod _method = null;
        private HttpContent _content = null;
        private string _requestUri = string.Empty;
        private string _bearerToken = string.Empty;
        private string _acceptHeader = "application/json";
        private TimeSpan _timeout = new TimeSpan(0, 0, 15);

        public HttpRequestBuilder()
        {
        }

        public HttpRequestBuilder AddMethod(HttpMethod method)
        {
            _method = method;
            return this;
        }

        public HttpRequestBuilder AddRequestUri(string requestUri)
        {
            _requestUri = requestUri;
            return this;
        }

        public HttpRequestBuilder AddContent(HttpContent content)
        {
            _content = content;
            return this;
        }

        public HttpRequestBuilder AddBearerToken(string bearerToken)
        {
            _bearerToken = bearerToken;
            return this;
        }

        public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            _acceptHeader = acceptHeader;
            return this;
        }

        public HttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            if (_method == null)
            {
                throw new ArgumentNullException("Method");
            }
            if (string.IsNullOrEmpty(_requestUri))
            {
                throw new ArgumentNullException("Request Uri");
            }

            var request = new HttpRequestMessage
            {
                Method = _method,
                RequestUri = new Uri(_requestUri)
            };

            if (_content != null)
            {
                request.Content = _content;
            }

            if (!string.IsNullOrEmpty(_bearerToken))
            {
                request.Headers.Authorization =
                  new AuthenticationHeaderValue("Bearer", _bearerToken);
            }

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(_acceptHeader))
            {
                request.Headers.Accept.Add(
                   new MediaTypeWithQualityHeaderValue(_acceptHeader));
            }

            var client = new HttpClient
            {
                Timeout = _timeout
            };

            return await client.SendAsync(request);
        }
    }
}
