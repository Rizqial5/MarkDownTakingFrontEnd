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

    public IEnumerable<MDData>? MDDatas {set;get;}
    

    public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task OnGet()
    {
        var sessions = await _apiClient.GetAllAsync();

        MDDatas = sessions;
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        await _apiClient.DeleteData(id);

        return RedirectToPage();
    }

    public int AddId()
    {
        return dataId++;
    }


}
