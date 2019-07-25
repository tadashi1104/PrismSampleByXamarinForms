using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleByXamarinForms.Models
{
    
    public class ServiceResultModel
    {
        public bool result { get; set; }

        public ErrorInformationModel errorInformation { get; set; }

        public class ErrorInformationModel
        {
            public string title { get; set; }
            public string message { get; set; }
        }
    }

}
