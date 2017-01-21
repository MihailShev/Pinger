using System;
using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnect
{
    public enum Result
    {
        timeout,
        unformat,
        error,
        succes
    }

    public class TestConnectInfo
    {
        public readonly string url;
        public readonly long time;
        public readonly Result result;

       internal TestConnectInfo(string url, long time, Result result)
        {
            this.url = url;
            this.time = time;
            this.result = result;
        }
    }

    public class Test
    {
        public TestConnectInfo TestUrl(string url, int timeout)
        {
            Stopwatch stopWatch = new Stopwatch();

            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Timeout = timeout;

                stopWatch.Start();
                WebResponse response = request.GetResponse();
                stopWatch.Stop();

                response.Close();

                TestConnectInfo info = new TestConnectInfo(url, stopWatch.ElapsedMilliseconds, Result.succes);
                return info;
                
            }
        
            catch (WebException exc)
            {
                if(exc.Status==WebExceptionStatus.Timeout)
                {
                   return  new TestConnectInfo(url, 0, Result.timeout);
                }

                return new TestConnectInfo(url, 0, Result.error);
                
            }

            catch (UriFormatException)
            {
                return new TestConnectInfo(url, 0, Result.unformat);
            }

        }
    }
}
