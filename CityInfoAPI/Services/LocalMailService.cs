namespace CityInfoAPI.Services
{
    public class LocalMailService : IMailService
    {
        private string _mailTo = "majid.asadollahi95@gmail.com";
        private string _mailFrom = "sales@eshopmvc.ir";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail From {_mailFrom} to {_mailTo} ," + $"with {nameof(LocalMailService)} , ");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message {message}");
        }
    }
}
