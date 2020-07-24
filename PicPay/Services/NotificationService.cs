using Newtonsoft.Json;
using PicPay.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PicPay
{
    public class NotificationService
    {
        public PicPayClient PicPayClient { get => new PicPayClient(); }
        public string Token { get => "SEU TOKEN AQUI"; }
        public async Task<NotificationResponse> Create(NotificationRequest body, string url)
        {
            PicPayClient.HttpClient.DefaultRequestHeaders.Remove("x-picpay-token");
            PicPayClient.HttpClient.DefaultRequestHeaders.Add("x-seller-token", Token);
            string json = JsonConvert.SerializeObject(body);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await PicPayClient.HttpClient.PostAsync(url, stringContent);
            NotificationResponse notificationResponse = 
                JsonConvert.DeserializeObject<NotificationResponse>(await response.Content.ReadAsStringAsync());
            notificationResponse.StatusCode = (int)response.StatusCode;
            PicPayClient.HttpClient.DefaultRequestHeaders.Remove("x-seller-token");
            PicPayClient.HttpClient.DefaultRequestHeaders.Add("x-picpay-token", PicPayClient.Token);
            return notificationResponse;
        }
    }
}