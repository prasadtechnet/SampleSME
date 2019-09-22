
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SME.Client.Services
{
    public class BaseService
    {
        private string _baseServiceUrl = "";
        private string _bearerToken = "";

        private HttpClient _httpClient;
     
        private string baseUrl;
        private IHttpContextAccessor _httpContext;

        public BaseService(string baseServiceUrl, IHttpContextAccessor httpContext)
        {                      
            _baseServiceUrl = baseServiceUrl;
            _httpContext = httpContext;
        }

      

        protected async Task<T> GetAsync<T>(string endpointUrl, bool AddTokenToHeader = true)
        {
            _httpClient = new HttpClient();

            if (AddTokenToHeader)
                AddTokenToHeaderOfRequest();

            var resp = await _httpClient.GetAsync(GetUri(endpointUrl), HttpCompletionOption.ResponseHeadersRead);
            resp.EnsureSuccessStatusCode();
            var data = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }
      

        protected async Task<T1> PostAsync<T1,T2>(string endpointUrl,T2 content,bool AddTokenToHeader=true)
        {
            _httpClient = new HttpClient();

            if (AddTokenToHeader)
                AddTokenToHeaderOfRequest();

            var resp=await _httpClient.PostAsync(GetUri(endpointUrl), CreateHttpContent<T2>(content));
            resp.EnsureSuccessStatusCode();
            var data = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T1>(data);
        }
     
        private Uri GetUri(string endpointUrl,string queryParams="")
        {
            var endpoint = new Uri(new Uri(_baseServiceUrl), endpointUrl);
            var builder = new UriBuilder(endpoint);
            builder.Query = queryParams;
            return builder.Uri;
        }
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        private void AddTokenToHeaderOfRequest()
        {
          
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _httpContext.HttpContext.Session.GetString("token"));
        }
        
    }
}
