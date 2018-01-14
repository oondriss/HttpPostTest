using HttpPostTest.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpPostTest
{
    class PostRequest
    {
        public static TestResult SendRequest(int order)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine($"starting request {order}");
            try
            {
                string Url = "http://192.168.1.1/2";

                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(Url);
                httpWReq.Timeout = int.MaxValue;
                Encoding encoding = new UTF8Encoding();
                
                string postData = "Neznášam svojho šéfa, je to najhorší človek na svete";
                byte[] data = encoding.GetBytes(postData);

                httpWReq.ProtocolVersion = HttpVersion.Version11;
                httpWReq.Method = "POST";
                
                httpWReq.ContentLength = data.Length;

                Stream stream = httpWReq.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                PostRequestData jsonObj;
                int responseCode;
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                responseCode = (int)response.StatusCode;
                
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String jsonresponse = "";
                String temp = null;
                while ((temp = reader.ReadLine()) != null)
                {
                    jsonresponse += temp;
                }

                jsonObj = JsonConvert.DeserializeObject<PostRequestData>(jsonresponse);
                stopWatch.Stop();

                var tr = new TestResult
                {
                    Result = jsonObj,
                    Duration = stopWatch.Elapsed,
                    HttpStatus = responseCode
                };
                Console.WriteLine($"finishing request {order}");
                return tr;
            }
            catch (WebException e)
            {
                TestResult tre;
                stopWatch.Stop();
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;

                    tre = new TestResult
                    {
                        Result = null,
                        Duration = stopWatch.Elapsed,
                        HttpStatus = (int)httpResponse.StatusCode
                    };
                }
                Console.WriteLine($"finishing bad request {order}");
                return tre;
            }
        }
    }
}
