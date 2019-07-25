using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleByXamarinForms.Models
{
    /// <summary>
    /// Base
    /// </summary>
    public class Response_Base
    {
        public string AppVersion { get; set; }
    }

    public class ApiResponseModels
    {
        public class Response_API_001
        {
            public string Id { get; set; }
            public int Type { get; set; }
            public int Status { get; set; }
        }

        public class Response_API_002 : Response_Base
        {

        }


        /// <summary>
        /// マスタ情報取得
        /// </summary>
        public class Response_API_999
        {
            public List<Master> Masters { get; set; }
            public class Master
            {
                public int Code { get; set; }
                public string Name { get; set; }
            }
        }
    }
}
