using System.Text.Json;
using System.Text;

namespace ShipManagementGUI.Services
{
    public abstract class Service
    {
        protected StringContent GetContentJSON(object dataToSerialize)
        {
            return new StringContent(
                    JsonSerializer.Serialize(dataToSerialize),
                    Encoding.UTF8,
                    "application/json");
        }

        protected async Task<T> DeserializeResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var deserializedResponse = JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);

            return deserializedResponse ?? default!;
        }

        protected bool ManageResponseErrors(HttpResponseMessage Response)
        {
            switch ((int)Response.StatusCode)
            {
                //Add rules if needed. 
                case 400:
                case 401:
                case 403:
                case 404:
                case 409:
                case 422:
                case 500:
                    return false;
            }

            Response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
