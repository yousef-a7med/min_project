using CarRentalMiniProject.Interfaces;

namespace CarRentalMiniProject.Services
{
    public class ConsoleNotificationService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"[Notification] {message}");
        }
    }
}
