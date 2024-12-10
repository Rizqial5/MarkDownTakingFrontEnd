using MarkDownTaking.API.Model;
using MarkDownTakingFrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarkDownTakingFrontEnd.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IApiClient _apiClient;

    public int dataId = 1 ;

    [BindProperty]
    public IEnumerable<MDData>? MDDatas {set;get;}

    [BindProperty]
    public string ResponseMessage{get;set;}
    

    public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task OnGet()
    {
        await UpdateData();
    }

    private async Task UpdateData()
    {
        var sessions = await _apiClient.GetAllAsync();
        

        MDDatas = sessions;
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        await _apiClient.DeleteData(id);

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpload(IFormFile fileUpload)
    {

        if(fileUpload == null || fileUpload.Length == 0)
        {
            SetResponseMessage("Please Upload a File");

            await UpdateData();

            return Page();
        }

        var extension = Path.GetExtension(fileUpload.FileName).ToLowerInvariant();
        string permittedExtension =  ".md";

        if(!permittedExtension.Contains(extension))
        {
        
            SetResponseMessage("Wrong type file, pleas upload .md file");
            
            await UpdateData();
            return Page();
        } 


        await _apiClient.PostMdFileAsync(fileUpload);

        SetResponseMessage("File uploaded succesfully");
        
        

        await UpdateData();

        return Page();
        
    }

    private void SetResponseMessage( string text)
    {
        ResponseMessage = text;
    }

    public int AddId()
    {
        return dataId++;
    }


}
