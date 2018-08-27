namespace NozzyTasks.Models.Requests
{
    public class TaskCompletionRequest
    {
        public long TaskId { get; set; }
        public bool Completed { get; set; }
    }
}