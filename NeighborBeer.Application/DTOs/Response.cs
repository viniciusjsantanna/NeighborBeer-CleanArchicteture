using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NeighborBeer.Application.DTOs
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public String Message { get; set; }
        public IList<String> Messages { get; set; } =  new List<string>();

        public void AddErrorMessages(string message)
        {
            Messages.Add(message);
            StatusCode = HttpStatusCode.InternalServerError;
        }
    }
}
