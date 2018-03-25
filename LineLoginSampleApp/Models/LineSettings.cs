using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineLoginSampleApp.Models
{
    public class LineSettings
    {
        public string LoginClientId { get; set; }
        public string LoginClientSecret { get; set; }
        public string MessagingAccessToken { get; set; }
    }
}
