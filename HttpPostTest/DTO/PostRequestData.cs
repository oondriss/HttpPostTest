using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostTest.DTO
{
    public class PostRequestData
    {
        //public string classification { get; set; }
        //public double p_neg { get; set; }
        //public double p_pos { get; set; }

        public double polarity { get; set; }
        public double subjectivity { get; set; }
        public string sentiment { get; set; }
        public string message { get; set; }
        public string message_orig { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
