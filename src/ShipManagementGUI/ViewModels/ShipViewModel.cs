using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ShipManagementGUI.ViewModels
{
    public class ShipViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; } = default!;

        [Required]
        [DisplayName("Code")]
        public string Code { get; set; } = default!;

        [Required]
        [DisplayName("Length")]
        public int Length { get; set; }

        [Required]
        [DisplayName("Width")]
        public int Width { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Code} {Length} - {Width}";
        }
    }
}
