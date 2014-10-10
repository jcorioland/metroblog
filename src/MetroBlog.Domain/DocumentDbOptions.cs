using System;

namespace MetroBlog.Domain
{
    public class DocumentDbOptions
    {
        public string EndpointUrl { get; set; }
        public string AuthorizationKey { get; set; }
        public string DatabaseId { get; set; }
    }
}