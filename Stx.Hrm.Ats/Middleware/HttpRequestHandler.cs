using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Stx.Hrm.Ats.Middleware
{
    public class HttpRequestHandler : DelegatingHandler
    {
        public HttpRequestHandler()
        {
        }

        public string Resource { get; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("Authorization"))
            {
                //request.Headers.Authorization
            }
            {
                // Fetch your token here
                var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJpc3MiOiJodHRwczovL3N0eGIyYy5iMmNsb2dpbi5jb20vYTgxNjllMjctMjM1OC00MjJiLTliOTYtYTlmZjZjZjUyNTEwL3YyLjAvIiwiZXhwIjoxNjM2MTc5NjIwLCJuYmYiOjE2MzYxNzYwMjAsImF1ZCI6IjUzNDE2M2Y3LWU4OTctNDI2MC04OGMwLTRiYmNmMTI3MTA4MCIsIm9pZCI6IjM1OGQ3ODc5LWI1MzEtNGI2OS04ZmU4LTZkMzZjODQ1NDcxMiIsInN1YiI6IjM1OGQ3ODc5LWI1MzEtNGI2OS04ZmU4LTZkMzZjODQ1NDcxMiIsImNvdW50cnkiOiJTaW5nYXBvcmUiLCJuYW1lIjoiQ2hpbmRpbDFBdHMgQ2ghbjE0IiwiZW1haWxzIjpbImNoaW5kaWwxQGdtYWlsLmNvbSJdLCJ0ZnAiOiJCMkNfMV9zaWdudXBzaWduaW4xIiwibm9uY2UiOiI5ZDRhY2Y4NS1lMzBlLTQ5MWYtYTU2NC1hODI4YjgyNmU5MGQiLCJzY3AiOiJBUEkuQWNjZXNzIiwiYXpwIjoiM2YyZGFlNTAtNWY3Ni00MmNmLWFjZmMtN2Y2YzE5ZTg5MmNiIiwidmVyIjoiMS4wIiwiaWF0IjoxNjM2MTc2MDIwLCJ1c3JpZCI6MSwiY29ycGlkIjoxfQ.rJt7B1lpanc3awYqG7EjdYOuO0vRfjS0bX4ZJKop01pyNnKGsnIcqLaBO0FmJGMsrmu4uEDBSxAQErXVf8kmZH-8I5-KnKcNS1vKEVFvMuqYdFg0ArY7ejfzNDKRJKyqDiMDZnHObrN-OzZ1KdUk-TDmYR9gnJf01RDfmop4FuqS4GnDYA-xTQr5PjZPNN9EfQkeJ5o4p1YX4p-oAlt4wS4OR-cLaYgTZ77n_7qoqcp5rOjmrYx1A_QssjOssDkmfvMXSnKpcCvhcloYxFokNRWexsbcBnxv7GZbaalaERbBTiRv13Bt5Q-Q74e-VbPKUNl4x3N43LKlUOzsV1J-Iw";
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
         
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
