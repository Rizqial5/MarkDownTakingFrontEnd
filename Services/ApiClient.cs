using System.Net;
using MarkDownTaking.API.Controllers;
using MarkDownTaking.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MarkDownTakingFrontEnd.Services
{
    class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteData(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/MarkDown/delete/{id}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return ;
            }

            response.EnsureSuccessStatusCode();
        }

        public IActionResult GenerateMDFile(RequestContent inputText)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MDData>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"/api/MarkDown");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<MDData>>();
        }

        public async Task<ShowData> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/MarkDown/{id}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ShowData>();
        }

        public async Task PostMdFileAsync(IFormFile fileUpload)
        {
            var multipartContent = new MultipartFormDataContent();

            using var fileStream = fileUpload.OpenReadStream();
            var fileContent = new StreamContent(fileStream)
            {
                Headers = 
                {
                    ContentType = new MediaTypeHeaderValue(fileUpload.ContentType),
                    ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "fileUpload",
                        FileName = fileUpload.FileName
                    }
                }
            };

            multipartContent.Add(fileContent, "fileUpload", fileUpload.FileName);

            var response = await _httpClient.PostAsync($"/api/MarkDown/upload", multipartContent);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return ;
            }

            response.EnsureSuccessStatusCode();

        
        }
    }
}