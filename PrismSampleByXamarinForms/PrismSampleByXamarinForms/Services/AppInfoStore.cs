using System;
using System.Collections.Generic;
using System.Text;
using PrismSampleByXamarinForms.Models;

namespace PrismSampleByXamarinForms.Services
{
    public class AppInfoStore
    {
        public static string token { get; set; }

        public static ApiResponseModels.Response_API_001 UserInfo { get; set; }

        public static class Masters
        {
            /// <summary>
            /// マスター 001
            /// </summary>
            public static List<Master_001> Masters_001 { get; set; }
            
            /// <summary>
            /// マスター 001
            /// </summary>
            public class Master_001
            {
                public int Code { get; set; }
                public string Name { get; set; }
            }
        }

        }
}
