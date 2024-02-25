
using System.Text.Json.Serialization;

namespace Omoqo.ShipManagement.Domain.Ships.Models
{
    public class Ship 
    {
        public Guid Id { get; private set; } // Primary Key
        public string Name { get; private set; }
        public int Length { get; private set; } // In meters
        public int Width { get; private set; } // In meters
        public string Code { get; private set; } // Format: AAAA-1111-A1
        
        public Ship(string name, int length, int width, string code)
        {
            Name = name;
            Length = length;
            Width = width;
            Code = code;
        }

        [JsonConstructor]
        public Ship(Guid id, string name, int length, int width, string code)
        {
            Id = id;
            Name = name;
            Length = length;
            Width = width;
            Code = code;
        }

        public void Update(string name, int length, int width, string code)
        {
            Name = name;
            Length = length;
            Width = width;
            Code = code;
        }
    }
}
