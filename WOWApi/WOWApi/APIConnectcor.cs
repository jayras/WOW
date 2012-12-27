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
        internal class APIConnector
        {
            public string Region { get; set; }
            public string HostName
            {
                get { return GetHostNameFromRegion(Region); }
            }

            public APIConnector(string region)
            {
                Region = region;
            }


            public string GetResponse(string uri)
            {
                UriBuilder build = new UriBuilder("http",HostName,80,uri);
                HttpWebRequest request = WebRequest.Create(build.Uri) as HttpWebRequest;

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
                        if (response != null)
                        {
                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    HttpWebResponse response = e.Response as HttpWebResponse;
                    WebExceptionStatus s = e.Status;
                    if (response != null)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }
                        throw new WOWAPIException((int)response.StatusCode, result, e);
                    }
                }

                return result;
            }

            private static string GetHostNameFromRegion(string region)
            {
                switch (region)
                {
                    case "en_US":
                    case "es_MX":
                    case "pt_BR":
                        return "us.battle.net";
                    case "en_GB":
                    case "es_ES":
                    case "fr_FR":
                    case "ru_RU":
                    case "de_DE":
                    case "pt_PT":
                    case "it_IT":
                        return "eu.battle.net";
                    case "ko_KR":
                        return "kr.battle.net";
                    case "zh_TW":
                        return "tw.battle.net";
                    case "zh_CN":
                        return "www.battlenet.com.cn";
                    default:
                        return "us.battle.net";

                }
            }

        }
    }


}
