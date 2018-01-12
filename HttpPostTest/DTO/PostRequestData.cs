using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostTest.DTO
{
    public class PostRequestData
    {
        public string classification { get; set; }
        public double p_neg { get; set; }
        public double p_pos { get; set; }
    }
}
