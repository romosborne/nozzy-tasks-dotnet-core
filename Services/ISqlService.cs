using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NozzyTasks.Models;

namespace NozzyTasks.Services
{
    public interface ISqlService
    {
        Task<IEnumerable<Project>> AllProjects(long userId);
        Task<NozzyTask> SingleTask(long taskId, long userId);
        Task<NozzyTask> CreateTask(NozzyTask task);
        Task SetTaskCompletion(long taskId, long userId, bool completion);
        Task<Project> CreateProject(Project project);

        Task AddUser(User user);
        Task CreateOrSetAuthToken(string sub, string email, string authToken);
        Task<User> GetUserFromAuthToken(string authToken);
    }
}