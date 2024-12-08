using MarkDownTaking.API.Controllers;
using MarkDownTaking.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace MarkDownTakingFrontEnd.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<MDData>> GetAllAsync();
        Task<ShowData> GetByIdAsync(int id);
        Task PostMdFileAsync( IFormFile fileUpload);
        Task DeleteData(int id);
        IActionResult GenerateMDFile(RequestContent inputText);
    }
    
}