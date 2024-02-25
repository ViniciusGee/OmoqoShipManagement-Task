using Microsoft.AspNetCore.Mvc;
using Omoqo.Shared.Notifications;
using Omoqo.Shared.Support.Constants;

namespace Omoqo.ShipManagement.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected IActionResult NotFoundResult(string errorCode, string error)
        {
            return NotFound(new
            {
                code = errorCode,
                description = error
            });
        }

        protected bool IsValidOperation()
        {
            return !_notifier.HasNotifications();
        }

        protected IActionResult InvalidOperationResult()
        {
            var notifications = _notifier.GetNotifications();
            var notFoundNotification = notifications.FirstOrDefault(n => n.Code == SharedErrorMessages.NotFoundCode);
            var forbidNotification = notifications.FirstOrDefault(n => n.Code == SharedErrorMessages.Forbid);
            var conflictNotification = notifications.FirstOrDefault(n => n.Code == SharedErrorMessages.Conflict);

            if (notFoundNotification is not null)
                return NotFound(notFoundNotification);

            if (forbidNotification is not null)
                return Forbid();

            if (conflictNotification is not null)
                return Conflict();

            return UnprocessableEntity(notifications);
        }
    }
}
