using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WOWApi
{
    class APIConnectcor
    {
        class APIConnector
        {
            public string Region { get; set; }
            public string BaseURI
            {
                get { return GetURIFromRegion(Region); }
            }

            public APIConnector()
            {

            }


            public string GetResponse(string uri)
            {
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

                if (request == null)
                {
                    throw new ArgumentException("Invalid URI");
                }

                request.Method = "GET";
                request.ContentType = "application/json";

                string result = null;
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    HttpWebResponse response = e.Response as HttpWebResponse;
                    WebExceptionStatus s = e.Status;
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }
                    throw new WOWAPIException((int)response.StatusCode, result, e);

                }

                return result;
            }

            private string GetURIFromRegion(string region)
            {
                throw new NotImplementedException();
            }

        }
    }
}
