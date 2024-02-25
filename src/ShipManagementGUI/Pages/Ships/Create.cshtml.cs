using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShipManagementGUI.Services;
using ShipManagementGUI.ViewModels;
using System.Net;

namespace ShipManagementGUI.Pages.Ships
{
    public class CreateShipModel : PageModel
    {
        [BindProperty]
        public ShipViewModel ship { get; set; } = default!;

        private readonly IShipManagementBffService _shipManagementBffService;

        public CreateShipModel(IShipManagementBffService shipManagementBffService)
        {
            _shipManagementBffService = shipManagementBffService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _shipManagementBffService.CreateShip(ship);

            if (response.Status == ((int)HttpStatusCode.Created))
                return RedirectToPage("/Index");
            else
            {
                ViewData["Message"] = "Something wrong, check the data.";
                return Page();
            }
        }
    }
}
