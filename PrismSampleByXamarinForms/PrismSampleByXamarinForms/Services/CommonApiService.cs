using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PrismSampleByXamarinForms.Models;
using PrismSampleByXamarinForms.Consts;

namespace PrismSampleByXamarinForms.Services
{
    public interface ICommonApiService
    {
        Task<string> GetToken(string email, string password = "password");
        Task<(bool result, ApiResponseModels.Response_API_999 returnBody, string message)> Send_API_999(string token, CommonEnums.MasterTypes type);

    }

    public class CommonApiService : ICommonApiService
    {
        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> GetToken(string email, string password = "password")
        {
            return await new Helpers.ApiSend().GetToken(email, password);
        }

        public async Task<(bool result, ApiResponseModels.Response_API_001 returnBody, string message)> Send_API_001(string email, int userCategory)
        {
            var request = new ApiRequestModels.Request_API_001
            {
                Email = email,
                UserType = userCategory
            };
            var response = await new Helpers.ApiSend().Send(ConstApiEndpoint.Param_API_001.url,
                ConstApiEndpoint.Param_API_001.method, null, JsonConvert.SerializeObject(request));

            using (HttpContent content = response.Content)
            {
                var resultContent = await content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, JsonConvert.DeserializeObject<ApiResponseModels.Response_API_001>(resultContent), null);
                }
                else
                {
                    return (false, null, resultContent);
                }
            }

        }

        /// <summary>
        /// マスタ情報取得
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type">マスタ種別</param>
        /// <returns></returns>
        public async Task<(bool result, ApiResponseModels.Response_API_999 returnBody, string message)> Send_API_999(string token, CommonEnums.MasterTypes type)
        {
            var request = new ApiRequestModels.Request_API_999
            {
                Type = (int)type
            };

            var response = await new Helpers.ApiSend().Send(ConstApiEndpoint.Param_API_999.url, ConstApiEndpoint.Param_API_999.method,
                                                            token, JsonConvert.SerializeObject(request));

            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, JsonConvert.DeserializeObject<ApiResponseModels.Response_API_999>(result), null);
                }
                else
                {
                    return (false, null, result);
                }
            }
        }
    }
}
