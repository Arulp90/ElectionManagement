

using System.Net.Http.Headers;
using System.Text;

namespace ElectionManagement.Web.Helper
{
    public interface IHttpHelper
    {
        Task<T> GetWebapiResponse<T>(string url);
        Task PostAsync(string url, string stringContent);
    }
    public class HttpHelper : IHttpHelper
    {

        public HttpHelper() { }

        public async Task<T> GetWebapiResponse<T>(string url)
        {
            T response = default;

            using (HttpClient client = new HttpClient())
            {
                //string url = "https://localhost:7032/api/Constituency/GetStates";
                var httpresponse = await client.GetAsync(url);
                if (httpresponse.IsSuccessStatusCode)
                {
                    var resul = httpresponse.Content.ReadAsStringAsync();
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resul.Result);
                }
            }
            return response;
        }

        public async Task PostAsync(string url, string stringContent)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PostAsync(
                        url,
                        content);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
