using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostTest.DTO
{
    public class TestResult
    {
        public TimeSpan Duration { get; set; }
        public int HttpStatus { get; set; }
        public PostRequestData Result { get; set; }
    }
}
