using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public class HttpUtils
    {
        private static string url = "";
        /// <summary>
        /// 获取数据（一般用于查询）。
        /// </summary>
        /// <param name="control_action">api地址（http://localhost:17212/api/Product/GetPrjShtData）中的控制器/方法名。</param>
        /// <param name="paramsdic">url中要拼接的参数，key值为action方法中的参数。</param>
        /// <returns></returns>
        public static string HttpGet(string control_action, Dictionary<string, string> paramsdic)
        {
          url = PrdConst.CSWebApiBaseUrl;
            if (string.IsNullOrEmpty(url)
                | string.IsNullOrEmpty(control_action))
            {
                MessageBox.Show("API地址有误，请检查！", "提示");
                return "failed";
            }
            url += control_action;
            //deal params.
            if (paramsdic != null)
            {
                StringBuilder builder = new StringBuilder();
                bool isfirst = true;
                foreach (string ky in paramsdic.Keys)
                {
                    if (isfirst)
                    {
                        builder.Append("?");
                        isfirst = false;
                    }
                    else
                    {
                        builder.Append("&");
                    }
                    builder.Append(ky);
                    builder.Append("=");
                    if (paramsdic[ky] == null)
                    {
                        builder.Append(paramsdic[ky]);
                    }
                    else
                    {
                        builder.Append(paramsdic[ky].Replace("#", "%23"));
                    }
                }
                if (builder.Length > 0)
                {
                    url += builder.ToString();
                }
            }
            string responseFromServer = string.Empty;
            HttpWebResponse response = null;
            try
            {
                // Create a request for the URL.   
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                // If required by the server, set the credentials.  
                request.Credentials = CredentialCache.DefaultCredentials;

                // Get the response.  
                response = (HttpWebResponse)request.GetResponse();
                // Display the status.  
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("连接失败！", "提示");
                    return "failed";
                }

                // Get the stream containing content returned by the server. 
                // The using block ensures the stream is automatically closed. 
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer = reader.ReadToEnd();
                }
                // Close the response.  
                response.Close();
            }
            catch (Exception ex)
            {
                responseFromServer = "failed:" + ex.ToString();
             //   CBase.AddErroLog("HttpGet:(" + DateTime.Now.ToString() + ")" + ex.ToString());
                if (response != null)
                    response.Close();
                if (!responseFromServer.Contains("409"))
                {
                    MessageBox.Show(ex.ToString(), "提示");
                }
            }
            return responseFromServer;
        }


            }
}

   
 