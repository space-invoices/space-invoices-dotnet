using System;
using System.Net;

namespace SpaceInvoices
{
    public class SpaceException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public SpaceError SpaceError { get; set; }
        public SpaceResponse SpaceResponse { get; set; }

        public SpaceException()
        {
        }

        public SpaceException(string message) : base(message)
        {
        }

        public SpaceException(string message, Exception err) : base(message, err)
        {
        }

        public SpaceException(HttpStatusCode httpStatusCode, SpaceError spaceError, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            SpaceError = spaceError;
        }
    }
}