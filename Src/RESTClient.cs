using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Litmos.API
{
    public class RESTClient
    {
        HttpClient _client;

        string _baseUri { get; set; }
        string _apikey { get; set; }
        string _source { get; set; }

        public RESTClient(string baseUri, string apiKey, string source)
        {
            _baseUri = baseUri;
            _apikey = apiKey;
            _source = source;
            _client = new HttpClient(baseUri, false);
        }

        /// <summary>
        /// Get a resource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public RESTResponse Get<T>(string requestUri)
        {
            return GetResponse<T>(_client.Get(GetUri(requestUri)));
        }

        /// <summary>
        /// Create a new resource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public RESTResponse Post<T>(string requestUri, object body)
        {
            return GetResponse<T>(_client.Post(GetUri(requestUri), body));
        }

        /// <summary>
        /// Create a new resource. No response body expected.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public RESTResponse Post(string requestUri, object body)
        {
            return GetResponse(_client.Post(GetUri(requestUri), body));
        }

        /// <summary>
        /// Update a resource
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public RESTResponse Put(string requestUri, object body)
        {
            return GetResponse(_client.Put(GetUri(requestUri), body));
        }

        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public RESTResponse Delete(string requestUri)
        {
            return GetResponse(_client.Delete(GetUri(requestUri)));
        }

        /// <summary>
        /// Get the HTTP request status and WCF response message as the supplied Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        RESTResponse GetResponse<T>(Message msg)
        {
            RESTResponse rs = new RESTResponse();
            rs.StatusCode = ((int)_client.GetStatusCode(msg)).ToString();
            rs.StatusDescription = _client.GetStatusDescription(msg);
            rs.Body = msg.GetBody<T>();
            
            return rs;
        }

        /// <summary>
        /// Get the HTTP request status
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        RESTResponse GetResponse(Message msg)
        {
            RESTResponse rs = new RESTResponse();
            rs.StatusCode = ((int)_client.GetStatusCode(msg)).ToString();
            rs.StatusDescription = _client.GetStatusDescription(msg);

            return rs;
        }

        /// <summary>
        /// Get the full request uri, including apikey and source values
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Uri GetUri(string uri)
        {
            if (!string.IsNullOrEmpty(uri) && !string.IsNullOrEmpty(_apikey) && !string.IsNullOrEmpty(_source))
            {
                uri = _baseUri
                    + uri
                    + (uri.Contains("?") ? string.Format("&apikey={0}&source={1}&start=0&limit=10000", _apikey, _source)
                        : string.Format("?apikey={0}&source={1}&start=0&limit=10000", _apikey, _source));

                return new Uri(uri);
            }
            else
            {
                return null;
            }
        }
    }
}
