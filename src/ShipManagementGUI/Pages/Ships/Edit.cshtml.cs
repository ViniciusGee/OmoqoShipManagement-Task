using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Omoqo.ShipManagement.Domain.Ships.Models;
using ShipManagementGUI.Services;
using ShipManagementGUI.ViewModels;
using System.Net;

namespace ShipManagementGUI.Pages.Ships
{
    public class EditModel : PageModel
    {
        private readonly IShipManagementBffService _shipManagementBffService;

        [BindProperty]
        public ShipViewModel shipViewModel { get; set; } = default!;

        public EditModel(IShipManagementBffService shipManagementBffService)
        {
            _shipManagementBffService = shipManagementBffService;
        }
        public async Task OnGet(Guid id)
        {
            var ship = await _shipManagementBffService.GetShip(id);

            if (ship != null)
                shipViewModel = ship;
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _shipManagementBffService.UpdateShip(shipViewModel);

            if (response.Status == ((int)HttpStatusCode.NoContent))
                ViewData["Message"] = "Ship updated successfully";
            else
            {
                ViewData["Message"] = "Something wrong, check the data.";
                return Page();
            }

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var response = await _shipManagementBffService.DeleteShip(shipViewModel.Id);

            if (response.Status == ((int)HttpStatusCode.NoContent))
                ViewData["Message"] = "Ship deleted successfully";
            else
            {
                ViewData["Message"] = "Something wrong, check the data.";
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
