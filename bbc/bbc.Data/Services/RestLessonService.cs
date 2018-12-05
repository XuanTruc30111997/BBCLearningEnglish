using AppConfig;
using bbc.Data.Interfaces;
using bbc.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bbc.Data.Services
{
    public class RestLessonService: IRestService<Lesson>
    {
        HttpClient httpClient;
        public RestLessonService()
        {
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Lesson>> GetDataAsync()
        {
            try
            {
                string json = await httpClient.GetStringAsync(Constant.RestLessonURL);
                var listLessons = JsonConvert.DeserializeObject<List<Lesson>>(json);
                return listLessons;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public Task<bool> PostDataAsync(Lesson obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutDataAsync(Lesson obj, string id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteDataAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
