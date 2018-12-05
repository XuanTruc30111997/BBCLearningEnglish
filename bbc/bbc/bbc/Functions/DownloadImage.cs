using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bbc.Functions
{
    public class DownloadImage
    {
        const int _downloadImageTimeoutInSeconds = 15;
        readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(_downloadImageTimeoutInSeconds) };

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            try
            {
                using (var httpResponse = await _httpClient.GetAsync(imageUrl))
                {
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return await httpResponse.Content.ReadAsByteArrayAsync();
                    }
                    else
                    {
                        //Url is Invalid
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                //Handle Exception
                return null;
            }
        }

        public async Task<byte[]> MyDonwload(string imageUrl)
        {
            WebClient webClient = new WebClient();
            byte[] myByte = null;
            try
            {
                myByte = await webClient.DownloadDataTaskAsync(imageUrl);
            }
            catch(Exception ex)
            {

            }
            
            return myByte;
        }
    }
}
