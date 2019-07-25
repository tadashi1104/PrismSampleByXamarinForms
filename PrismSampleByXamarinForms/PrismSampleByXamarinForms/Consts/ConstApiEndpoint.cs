using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PrismSampleByXamarinForms.Consts
{
    public static class ConstApiEndpoint
    {
        public static class Param_API_001 { static public HttpMethod method { get => HttpMethod.Get; } static public string url { get => "/Account/User"; } }
        public static class Param_API_002 { static public HttpMethod method { get => HttpMethod.Post; } static public string url { get => "/Users"; } }
        public static class Param_API_003
        {
            static public HttpMethod method { get => HttpMethod.Delete; }
            static public string url { get => $"/Users?id={id}&type={type}"; }
            static public string id { private get; set; }
            static public string type { private get; set; }
        }
        public static class Param_API_999 { static public HttpMethod method { get => HttpMethod.Get; } static public string url { get => "/Masters"; } }
    }
}
