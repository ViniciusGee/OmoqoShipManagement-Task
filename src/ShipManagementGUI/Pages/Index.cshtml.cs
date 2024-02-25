using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShipManagementGUI.Services;
using ShipManagementGUI.ViewModels;


namespace ShipManagementGUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IShipManagementBffService _shipManagementBffService;
        public IEnumerable<ShipViewModel> shipList { get; set; } = default!;

        public IndexModel(IShipManagementBffService shipManagementBffService)
        {
            _shipManagementBffService = shipManagementBffService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            shipList = await _shipManagementBffService.GetAllShips();
            return Page();
        }
    }
}
