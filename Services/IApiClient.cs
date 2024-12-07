using MarkDownTaking.API.Controllers;
using MarkDownTaking.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace MarkDownTakingFrontEnd.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<MDData>> GetAllAsync();
        Task<ActionResult<MDData>> GetByIdAsync(int id);
        Task<ActionResult> PostMdFileAsync( IFormFile fileUpload);
        IActionResult GenerateMDFile(RequestContent inputText);
    }
    
}