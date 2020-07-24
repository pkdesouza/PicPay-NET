using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;

namespace PicPay
{
    public class PicPayClient
    {
        internal const string BaseAddress = "https://appws.picpay.com/ecommerce/public/";
        public HttpClient HttpClient = null;
        internal static string Token = "SEU TOKEN AQUI";
        public PicPayClient()
        {
            if (HttpClient == null)
            {
                HttpClient = new HttpClient();
                HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpClient.DefaultRequestHeaders.Add("User-Agent", $"PicPay {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}");
                HttpClient.BaseAddress = new Uri(BaseAddress);
                HttpClient.DefaultRequestHeaders.Add("x-picpay-token", Token);
            }
        }
    }
}
