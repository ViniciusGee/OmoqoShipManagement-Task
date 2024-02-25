using FluentAssertions;
using Omoqo.ShipManagement.Application.Ships.Commands;
using Xunit;

namespace Omoqo.ShipManagement.Application.Tests.Ships
{
    public class CreateShipTests
    {
        [Test]
        [Fact(DisplayName = "It must return false, when the name is not provided.")]
        [Trait("Category", "Commands")]
        public void IsValid_WithEmptyName_ReturnFalse()
        {
            var ship = new CreateShipCommand
            {
                Name = "",
                Length = 100,
                Width = 100,
                Code = "AAAA-1111-B9"    
            };

            ship.IsValid();

            var notifications = ship.GetNotifications();

            notifications.Should().HaveCount(1);

            var shipErrorNameDescription = string.Format(TestMessages.EmptyName, "Ship's name");

            notifications.SingleOrDefault(x => x.Code == "Name")!.Description.Should().Be(shipErrorNameDescription);
        }

        
        [Fact(DisplayName = "It must return false, when code is not right")]
        [Trait("Category", "Commands")]
        [Test()]
        public void IsValid_WithWrongCodeFormat_ReturnFalse()
        {
            var ship = new CreateShipCommand
            {
                Name = "ShipTest",
                Length = 100,
                Width = 100,
                Code = "1-111-b9"
            };

            ship.IsValid();

            var notifications = ship.GetNotifications();

            notifications.Should().HaveCount(1);

            notifications.SingleOrDefault(x => x.Code == "Code")!.Description.Should().Be(TestMessages.CodeWrongFormat);
        }

        ///Add many more...

    }
}
