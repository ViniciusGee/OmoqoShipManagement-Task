using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Omoqo.ShipManagement.Application.Ships.Commands;
using Omoqo.ShipManagement.Domain.Ships.Models;
using ShipManagementGUI.Settings;
using ShipManagementGUI.Utility;
using ShipManagementGUI.ViewModels;
using System.Net.Http;

namespace ShipManagementGUI.Services
{
    public class ShipManagementBffService : Service, IShipManagementBffService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ShipManagementBffService(HttpClient httpClient, IMapper mapper, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShipManagementApiUrl);

            _mapper = mapper;
        }

        public async Task<ResponseResult> CreateShip(ShipViewModel ship)
        {
            var createShipCommand = GetContentJSON(_mapper.Map<CreateShipCommand>(ship));

            var response = await _httpClient.PostAsync("create-ship", createShipCommand);

            if (!ManageResponseErrors(response))
                return await DeserializeResponse<ResponseResult>(response);
            
            return new ResponseResult{ Status = (int)response.StatusCode }; 
        }

        public async Task<ResponseResult> UpdateShip(ShipViewModel ship)
        {
            var updateShipCommand = GetContentJSON(_mapper.Map<UpdateShipCommand>(ship));

            var response = await _httpClient.PutAsync($"update-ship/{ship.Id}", updateShipCommand);

            if (!ManageResponseErrors(response))
                return await DeserializeResponse<ResponseResult>(response);

            return new ResponseResult { Status = (int)response.StatusCode };
        }

        public async Task<ResponseResult> DeleteShip(Guid Id)
        {
            var response = await _httpClient.DeleteAsync($"delete-ship/{Id}");

            if (!ManageResponseErrors(response))
                return await DeserializeResponse<ResponseResult>(response);

            return new ResponseResult { Status = (int)response.StatusCode };
        }
        public async Task<IEnumerable<ShipViewModel>> GetAllShips()
        {
            var response = await _httpClient.GetAsync("all-ships");

            if (!ManageResponseErrors(response))
                return new List<ShipViewModel>();  //TODO add a msg to the user knkow has been an error

            var apiResult = await DeserializeResponse<IEnumerable<Ship>>(response);

            return _mapper.Map<IEnumerable<ShipViewModel>>(apiResult);
        }

        public async Task<ShipViewModel> GetShip(Guid Id)
        {
            var response = await _httpClient.GetAsync($"get-ship/{Id}");

            if(!ManageResponseErrors(response))
                return new ShipViewModel(); //TODO add a msg to the user knkow has been an error

            var apiResult = await DeserializeResponse<Ship>(response);

            return _mapper.Map<ShipViewModel>(apiResult);
          
        }
    }
}
