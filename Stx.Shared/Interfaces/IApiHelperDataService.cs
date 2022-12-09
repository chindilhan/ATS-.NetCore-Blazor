using Stx.Shared.Common;
using Stx.Shared.Status;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stx.Shared.Interfaces
{
    public interface IApiHelperDataService
    {
        public Task<HttpResponseMessage> GetAllRecords(string endpoint);
        public Task<HttpResponseMessage> GetData(string endpointWithParm);
        //public Task<HttpResponseMessage> GetData(string endpoint, StringContent serializedStringRecord);
        public Task<HttpResponseMessage> GetDataByID(int id, string endpoint);
        public Task<HttpResponseMessage> GetDataByCD(string code, string endpoint, bool isReqEncodeCodeParm = true);

        public Task<HttpResponseMessage> PostData(string endpoint, StringContent serializedStringRecord);
        public Task<HttpResponseMessage> PostData(string endpoint, HttpContent httpContent);

        //public Task<HttpResponseMessage> PartialUpdateData(string endpoint, StringContent serializedStringRecord);
        public Task<HttpResponseMessage> PatchData(string endpoint, StringContent serializedStringRecord);

        //[Obsolete("Method1 is deprecated, please use PostData or PartialUpdateData instead.")]
        //public Task<HttpResponseMessage> UpdateData (StringContent serializedStringRecord, EntryState entryState, string endpoint, string userId);
        
        public Task<HttpResponseMessage> DeleteData(string endpointWithParm);
        public Task<HttpResponseMessage> DeleteRecord(string endpoint, int docnum, string userId);

        public Task<HttpResponseMessage> UploadFile(string endpoint, MultipartFormDataContent content, string userId);

    }
}
