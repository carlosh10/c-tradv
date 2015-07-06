using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TradeAdvisor.Controllers
{
    public class ConsultaController
    {

        public static string GeraPost(string url, string postData)
        {
            // Create a request using a URL that can receive a post. 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Proxy = null;

            request.KeepAlive = false;
            
            // Set the Method property of the request to POST.
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; Media Center PC 6.0; InfoPath.3; MS-RTC LM 8; Zune 4.7)";
            // Create POST data and convert it to a byte array.            
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Get the response.
            // Get the request stream.
            //Stream dataStream = request.GetRequestStream();
            WebResponse response = null;
            // Get the response.
            bool siteInoperante = true;
            StreamReader reader = null;
            string responseFromServer = "";

            while (siteInoperante)
            {
                try
                {
                    response = request.GetResponse();
                }
                catch (Exception x)
                {
                    response = null;
                    if ((x.Message.ToString() == "The remote server returned an error: (500) Internal Server Error.") || (x.Message.ToString() == "The operation has timed out"))
                    {
                        //Aguarda site retornar
                        response = request.GetResponse();
                    }
                    else
                        throw new Exception("Erro ao realizar GET." + x.ToString());
                }
                // Display the status.
                // Get the stream containing content returned by the server.
                //dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true);

                // Read the content.
                responseFromServer = reader.ReadToEnd();

            }

            dataStream.Close();
            reader.Close();
            response.Close();


            //Aguarda um segundo para fazer outra solicitação
            //O site não aceita requisições simultaneas do mesmo usuário
            System.Threading.Thread.Sleep(3000);

            return responseFromServer;
        }
    }
}