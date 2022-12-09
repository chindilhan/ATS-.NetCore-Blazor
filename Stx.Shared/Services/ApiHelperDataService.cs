using Stx.Shared.Interfaces;
using Stx.Shared.Status;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Stx.Shared.Services
{
    public class ApiHelperDataService : IApiHelperDataService
    {
        //private IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        //public static HttpClient HttpClientInit { private get; set; }

        //public static void Init(HttpClient httpClient)
        //{
        //    //HttpClientInit = httpClient;
        //}
        //public ApiHelperDataService(HttpClient httpClient)
        //{
        //    //if (_httpClient == null) _httpClient = HttpClientInit;
        //}

        //public ApiHelperDataService(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        //    _httpClient = httpClientFactory.CreateClient("JPAPI");
        //}

        //public ApiHelperDataService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        //    public ApiHelperDataService(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClient = httpClientFactory.CreateClient("JPAPI");
        //    //httpContextAccessor = httpContextAccessor;
        //    //if (_httpClient == null) _httpClient = HttpClientInit;
        //}

        public ApiHelperDataService(IHttpClientFactory httpClientFactory)
        {
            IHttpClientFactory _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = _httpClientFactory.CreateClient("JPAPI");
        }

        #region Get Records
        public async Task<HttpResponseMessage> GetAllRecords(string endpoint)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _httpClient.GetAsync($"{endpoint}");
        }

        public async Task<HttpResponseMessage> GetData(string endpointWithInlineParm)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.GetAsync($"{endpointWithInlineParm}");
            return response;
        }

        public async Task<HttpResponseMessage> GetDataByID(int id,string endpoint)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.GetAsync($"{endpoint}/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> GetDataByCD(string code, string endpoint, bool isReqEncodeCodeParm=true)
        {
            if(isReqEncodeCodeParm) code = HttpUtility.UrlEncode(code);

            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _httpClient.GetAsync($"{endpoint}/{code}/", HttpCompletionOption.ResponseHeadersRead);
        }
        #endregion 

        #region ADD-Update Record

        //[Obsolete("Method1 is deprecated, please use PostData or PartialUpdateData instead.")]
        //public async Task<HttpResponseMessage> UpdateData(StringContent serializedStringRecord, EntryState entryState, string endpoint, string userId)
        //{
        //    if (entryState == EntryState.New) //POST
        //    {
        //        //_httpClient.DefaultRequestHeaders.Accept.Clear();
        //        //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = await _httpClient.PostAsync($"{endpoint}", serializedStringRecord);
        //        return response;  
        //    }
        //    else if (entryState == EntryState.Update) //PUT
        //    {
        //        //    _httpClient.DefaultRequestHeaders.Accept.Clear();
        //        //    _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = await _httpClient.PutAsync($"{endpoint}", serializedStringRecord);
        //        return response;
        //    }
        //    return null;
        //}


        public async Task<HttpResponseMessage> PostData(string endpoint, StringContent serializedStringRecord)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.PostAsync($"{endpoint}", serializedStringRecord);
            return response;
        }

        public async Task<HttpResponseMessage> PostData(string endpoint, HttpContent httpContent)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.PostAsync($"{endpoint}", httpContent);
            return response;
        }

        /// <summary>
        /// PUT requests to create or replace the resource.
        /// </summary>
        /// <param name="endpoint">Endpoint name</param>
        /// <param name="serializedStringRecord">Serialized payload</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PutData(string endpoint, StringContent serializedStringRecord)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.PutAsync($"{endpoint}", serializedStringRecord);
            return response;
        }

        /// <summary>
        /// PATCH requests to update parts of the resource
        /// </summary>
        /// <param name="endpoint">Endpoint name</param>
        /// <param name="serializedStringRecord">Serialized payload</param>
        /// <returns></returns>
        [Obsolete("This method only can be used after upgrade to .net core 5 or later. Please use PostData instead for prior .net core 5.")]
        public async Task<HttpResponseMessage> PatchData(string endpoint, StringContent serializedStringRecord)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.PatchAsync($"{endpoint}", serializedStringRecord);
            return response;
        }
        #endregion


        #region Delete Record
        public async Task<HttpResponseMessage> DeleteRecord(string endpoint, int docnum, string userId)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _httpClient.DeleteAsync($"{endpoint}/{docnum}");
        } 
        
        public async Task<HttpResponseMessage> DeleteData(string endpointWithInlineParm)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return await _httpClient.DeleteAsync(endpointWithInlineParm);
        }
        #endregion


        #region Upload a File 
        public async Task<HttpResponseMessage> UploadFile(string endpoint, MultipartFormDataContent content, string userId)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            //var postResult = await _httpClient.PatchAsync($"{endpoint}", content);
            var postResult = await _httpClient.PostAsync($"{endpoint}", content);
            return postResult;
            //var postContent = await postResult.Content.ReadAsStringAsync();
            //if (!postResult.IsSuccessStatusCode)
            //{
            //    throw new ApplicationException(postContent);
            //}
            //else
            //{
            //    var imgUrl = Path.Combine("https://localhost:5011/", postContent);
            //    return imgUrl;
            //}
        }
        #endregion

    }
}
