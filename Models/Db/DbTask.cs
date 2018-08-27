namespace NozzyTasks.Models.Db
{
    public class DbTask
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public long Project { get; set; }
    }
}