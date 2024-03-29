﻿using Newtonsoft.Json;
using PC.AccessLayer.Models;
using PC.AccessLayer.Services.IServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PC.AccessLayer.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.responseModel = new ResponseDto();
        }

        public T SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                T apiResponseDto = ProcessRequest<T>(apiRequest);

                return apiResponseDto;
            }
            catch (Exception ex)
            {
                T apiResponseDto = CatchError<T>(ex);
                return apiResponseDto;
            }
        }
        private T ProcessRequest<T>(ApiRequest apiRequest)
        {
            var client = httpClient.CreateClient("MangoAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(
                    JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json"
                    );
            }

            //if (!string.IsNullOrEmpty(apiRequest.AccessToken))
            //{
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
            //}

            HttpResponseMessage apiResponse = null;
            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = client.Send(message);

            var apiContent = apiResponse.Content.ReadAsStringAsync().Result;
            var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
            return apiResponseDto;
        }

        private static T CatchError<T>(Exception ex)
        {
            var dto = new ResponseDto
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                IsSuccess = false
            };
            var res = JsonConvert.SerializeObject(dto);
            var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
            return apiResponseDto;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
