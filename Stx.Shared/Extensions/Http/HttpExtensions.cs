using Stx.Shared.Exceptions;
using Stx.Shared.Models.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stx.Shared.Extensions.Http
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task EnsureSuccessStatusCode2(this HttpResponseMessage message, string content = null)
        {
            if (message.IsSuccessStatusCode)
                return;

            //var respMsg = await Task.Run(async () =>
            //{
                var respMsg = await GetResponseMsgAsync(message);
            //}

            //var respMsg = GetResponseMsgAsync(message);
            throw new StxHttpResponseException(string.Format(CultureInfo.InvariantCulture, "{0}", respMsg), message.StatusCode);

            //var contentMessage = string.IsNullOrWhiteSpace(content) ? string.Empty : $"Content: {content}";
            //throw new HttpRequestException(string.Format(
            //    System.Globalization.CultureInfo.InvariantCulture,
            //    "Internal error : {0} ({1}).{2}",
            //    (int)message.StatusCode,
            //    message.ReasonPhrase,
            //    respMsg)
            //    );
        }

        private static async Task<string> GetResponseMsgAsync(HttpResponseMessage message)
        {
            try
            {
                var msg = await message.Content.ReadAsStringAsync();
                var json = JsonSerializer.Serialize(message.ToString());

                if (string.IsNullOrWhiteSpace(msg) && 
                    (message.StatusCode == System.Net.HttpStatusCode.Unauthorized || message.StatusCode == System.Net.HttpStatusCode.Forbidden))
                {
                    return "You may have no enough permission to access this page.";
                }

                //dynamic resultResponsedynamic = JsonSerializer.Deserialize<dynamic>(msg, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                var resultResponse = JsonSerializer.Deserialize<ErrorDetails>(msg, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if (resultResponse != null && !string.IsNullOrWhiteSpace(resultResponse.Message))
                    return resultResponse.Message;
            }
            catch { }
             
            return "Internal server error. Please try again.";
        }
    }
}
