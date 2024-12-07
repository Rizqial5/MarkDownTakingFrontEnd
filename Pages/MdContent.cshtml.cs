using MarkDownTaking.API.Controllers;
using MarkDownTaking.API.Model;
using MarkDownTakingFrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarkDownTakingFrontEnd.Pages
{
    public class MdContentModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public ShowData? Data {set;get;}

        public MdContentModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGet(int id)
        {
            var selectedData = await _apiClient.GetByIdAsync(id);

            Data = selectedData;
        }
    }
}
