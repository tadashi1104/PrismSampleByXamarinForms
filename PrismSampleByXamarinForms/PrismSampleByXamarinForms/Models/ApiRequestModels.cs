using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleByXamarinForms.Models
{
    class ApiRequestModels
    {
        public class Request_API_001
        {
            public string Email { get; set; }
            public int UserType { get; set; }
        }

        public class Request_API_002
        {
            public string Sei { get; set; }
            public string Mei { get; set; }
            public string SeiKana { get; set; }
            public string MeiKana { get; set; }
            public string ZipCode { get; set; }
            public string Prefecture { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public string PhoneNumber { get; set; }
            public string AccountNumber { get; set; }
        }


        /// <summary>
        /// マスタ情報取得
        /// </summary>
        public class Request_API_999
        {
            public int Type { get; set; }
        }
    }
}
