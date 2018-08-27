using System.Collections.Generic;

namespace NozzyTasks.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public IEnumerable<NozzyTask> Tasks {get;set;}
    }
}