using FluentValidation;
using System.Text;

namespace Omoqo.Shared.Notifications
{
    public abstract class Notifiable
    {
        public abstract bool IsValid();

        private readonly List<Notification> _notifications = new();
        protected bool HasNotifications => _notifications.Any();

        public IEnumerable<Notification> GetNotifications() => _notifications.Distinct();
        public IEnumerable<Notification> GetAllNotifications() => _notifications;
        public void AddNotification(string property, string description) => _notifications.Add(new Notification(property, description));
        protected void Validate(Notifiable validable) => UpdateValidation(validable.GetNotifications());

        protected bool ValidateObject(IValidator validator)
        {
            var context = new ValidationContext<object>(this);
            var result = validator.Validate(context);

            foreach (var item in result.Errors)
            {
                AddNotification(item.PropertyName, item.ErrorMessage);
            }

            return !HasNotifications;
        }

        public void EnsureValidation()
        {
            if (IsValid()) return;

            var notifications = new StringBuilder();

            foreach (var notification in _notifications)
                notifications.AppendLine(notification.ToString());

            throw new InvalidOperationException(notifications.ToString());
        }

        protected void UpdateValidation(IEnumerable<Notification> notifications)
        {
            if (!HasNotifications) return;

            foreach (var notification in notifications)
                _notifications.Add(notification);
        }
    }
}