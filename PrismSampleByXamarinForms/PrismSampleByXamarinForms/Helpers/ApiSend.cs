using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PrismSampleByXamarinForms.Consts;

namespace PrismSampleByXamarinForms.Helpers
{
    class ApiSend
    {
        static HttpClient client = new HttpClient();

        /// <summary>
        /// アクセストークンを取得します。
        /// </summary>
        /// <param name="email">ユーザメールアドレス</param>
        /// <param name="password">ログインパスワード(テスト用ユーザは省略可)</param>
        /// <returns>アクセストークンを返却します</returns>
        public async Task<string> GetToken(string email, string password = "password")
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post
                                            , $"{CommonConsts.baseUrl.Replace("/api", "")}/Token");
            request.Content = new StringContent($@"grant_type=password&username={email}&password={password}"
                                                    , Encoding.UTF8, "application/x-www-form-urlencoded");

            using (var response = await client.SendAsync(request))
            {
                var content = await response.Content.ReadAsStringAsync();

                TokenResponse model = JsonConvert.DeserializeObject<TokenResponse>(content);
                return $"{model.token_type} {model.access_token}";
            }
        }

        internal Task Send(object url, object method, object p, string v)
        {
            throw new NotImplementedException();
        }

        internal Task Send(object url, object method, object p1, object p2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// API呼び出し
        /// </summary>
        /// <param name="url">呼び出し対象URL</param>
        /// <param name="httpMethod">HTTPメソッド</param>
        /// <param name="dic">ボディにセットするdictionaly</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Send(string url, HttpMethod httpMethod, string token = null, string json = null)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(httpMethod, $@"{CommonConsts.baseUrl}{CommonConsts.apiVersion}{url}");


                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }

                if (!string.IsNullOrEmpty(json))
                {
                    var body = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = body;
                }

                return await client.SendAsync(request);

            }
            catch
            {
                throw;
            }
            finally
            {
                client = new HttpClient();
            }

        }

        public class TokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
        }
    }
}
