using ExchangeRates.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.OutsideEndpoints
{
    public class HttpGrabber
    {
        private string baseAddress = "https://api.nbp.pl/api/";

        //https:///api.nbp.pl/api/exchangerates/tables/a/?format=json

        /// <summary>
        /// Serialize List of Root
        /// </summary>
        public async Task<Root> GetExchangeRates()
        {
            List<Root> rootModel = new List<Root>();
            try
            {
                rootModel = JsonConvert.DeserializeObject<List<Root>>(await GetFromHttp());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message.ToString();
            }

            return rootModel.First();
        }

        /// <summary>
        /// Get data from http
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetFromHttp()
        {
            string resultRequest = "";
            try
            {
                //Creating an http address
                var requestAddress = HttpWebRequest.CreateHttp(baseAddress + "exchangerates/tables/a/?format=json"); 

                requestAddress.Method = WebRequestMethods.Http.Get; 
                requestAddress.Accept = "application/json; charset=utf-8"; 


                await Task.Factory.FromAsync<WebResponse>(requestAddress.BeginGetResponse, requestAddress.EndGetResponse, null).ContinueWith(task =>
                {
                    HttpWebResponse resposne = (HttpWebResponse)task.Result;

                    if (resposne.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader responseReader = new StreamReader(resposne.GetResponseStream(), Encoding.UTF8);
                        string responseData = responseReader.ReadToEnd();

                        resultRequest = responseData.ToString();
                        responseReader.Close();
                    }

                    resposne.Close();

                });

            }
            catch (Exception ex)
            {
                var cos = ex;
            }

            return resultRequest;
        }
    }
}
