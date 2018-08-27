namespace NozzyTasks.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Sub { get; set; }
        public string Email { get; set; }
        public string AuthToken { get; set; }
    }
}