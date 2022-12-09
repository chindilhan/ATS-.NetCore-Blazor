using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Stx.Shared.Exceptions
{
    [Serializable]
    public class StxHttpResponseException: Exception
    {
        public string PublicMessage { get; }
        public HttpStatusCode StatusCode { get; }

        //public StxException() { }
        //public StxException(string message): base(message) { }

        public StxHttpResponseException(string message, Exception inner)
            : base(message, inner) { }

        public StxHttpResponseException(Exception exception, string publicMessage, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
            : this(publicMessage, exception)
        {
            PublicMessage = publicMessage;
            StatusCode = httpStatusCode;
        }

        public StxHttpResponseException(string publicMessage, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
           : this(publicMessage, null)
        {
            PublicMessage = publicMessage;
            StatusCode = httpStatusCode;
        }
    }
}

