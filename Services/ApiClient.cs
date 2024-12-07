using System.Net;
using MarkDownTaking.API.Controllers;
using MarkDownTaking.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace MarkDownTakingFrontEnd.Services
{
    class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

        public Task<ActionResult> PostMdFileAsync(IFormFile fileUpload)
        {
            throw new NotImplementedException();
        }
    }
}