﻿using Newtonsoft.Json;
using PicPay.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PicPay
{
    public class PaymentService
    {
        public PicPayClient PicPayClient { get => new PicPayClient(); }
        public async Task<PaymentResponse> Create(PaymentRequest body)
        {
            string json = JsonConvert.SerializeObject(body);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await PicPayClient.HttpClient.PostAsync("payments", stringContent);
            PaymentResponse paymentResponse = 
                JsonConvert.DeserializeObject<PaymentResponse>(await response.Content.ReadAsStringAsync());
            paymentResponse.StatusCode = (int)response.StatusCode;
            return paymentResponse;
        }
        public async Task<PaymentResponse> Cancel(PaymentRequest body, string referenceId)
        {
            string json = JsonConvert.SerializeObject(body);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = 
                await PicPayClient.HttpClient.PostAsync($"payments/{referenceId}/cancellations", stringContent);
            PaymentResponse paymentResponse = 
                JsonConvert.DeserializeObject<PaymentResponse>(await response.Content.ReadAsStringAsync());
            paymentResponse.StatusCode = (int)response.StatusCode;
            return paymentResponse;
        }
        public async Task<PaymentResponse> Status(string referenceId)
        {
            HttpResponseMessage response = await PicPayClient.HttpClient.GetAsync($"payments/{referenceId}/status");
            PaymentResponse paymentResponse = 
                JsonConvert.DeserializeObject<PaymentResponse>(await response.Content.ReadAsStringAsync());
            paymentResponse.StatusCode = (int)response.StatusCode;
            return paymentResponse;
        }
    }
}