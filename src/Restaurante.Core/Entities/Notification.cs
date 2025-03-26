using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities
{
    public class Notification : Entity
    {
        public int UserId { get; private set; }  // ID do usuário ou destinatário
        public string Title { get; private set; }
        public string Message { get; private set; }
        public bool IsRead { get; private set; }  // Para saber se a notificação foi lida
        public string? RedirectUrl { get; private set; }

        public Notification()
        {
            
        }

        public Notification(int userId, string title, string message, string? redirectUrl)
        {
            UserId = userId;
            Title = title;
            Message = message;
            IsRead = false;
            RedirectUrl = redirectUrl;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
