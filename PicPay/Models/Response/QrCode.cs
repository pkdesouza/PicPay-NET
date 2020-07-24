using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PicPay.Models.Response
{
    public class QrCode
    {
        [JsonProperty("content", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Content { get; set; }
        [JsonProperty("base64", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Base64 { get; set; }
    }
}
