namespace nozzy_tasks_dotnet_core.Models.Requests
{
    public class TaskRequest
    {
        public string Title { get; set; }
        public long ProjectId { get; set; }
        public string NewProjectName { get; set; }
    }
}