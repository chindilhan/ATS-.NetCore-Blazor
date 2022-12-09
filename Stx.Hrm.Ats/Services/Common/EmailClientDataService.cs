using Stx.Shared.Interfaces;
using Stx.Shared.Interfaces.Common;
using Stx.Shared.Models.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Stx.HRM.Services.Common
{
    public class EmailClientDataService : IEmailClientDataService
    {
        private readonly IApiHelperDataService _apiHelperDataService;
        public EmailClientDataService(IApiHelperDataService apiHelperDataService)
        {
            _apiHelperDataService = apiHelperDataService;
        }

        public async Task<List<EmailTemplate>> GetEmailTemplates(int jobOrderId)
        {
            using var response = await _apiHelperDataService.GetDataByID(jobOrderId, "EmailClient");
            {
                response.EnsureSuccessStatusCode();
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<EmailTemplate>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<bool> Send(EmailMsg emailMsg)
        {
            var serializeJson = new StringContent(JsonSerializer.Serialize(emailMsg), Encoding.UTF8, "application/json");
            var response = await _apiHelperDataService.PostData("EmailClient", serializeJson);
            response.EnsureSuccessStatusCode();
            return true;
        }



    }
}
