using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Extensions.Options;
using Microsoft.Data.Sqlite;
using NozzyTasks.Models;
using NozzyTasks.Models.Db;
using NozzyTasks.Models.Options;
using System.Data.SQLite;

namespace NozzyTasks.Services
{
    public class SqlService : ISqlService
    {

        private IDbConnection _conn;
        private IDbConnection Conn
        {
            get
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
                return _conn;
            }
        }

        public SqlService(IOptions<SqlOptions> sqlOptions)
        {
            _conn = new SQLiteConnection(sqlOptions.Value.ConnectionString);
        }

        public async Task<IEnumerable<Project>> AllProjects(long userId)
        {
            // Grab the projects
            var dbps = await Conn.QueryAsync<DbProject>(
                $@"select * from projects where userId = {userId}");

            var pids = dbps.Select(dbp => dbp.Id);

            // Grab the tasks
            var dbts = Conn.Query<DbTask>(@"select * from tasks where project in @Pids",
                new { Pids = pids });

            var projects = new List<Project>();
            foreach (var dbp in dbps)
            {
                var project = new Project()
                {
                    Id = dbp.Id,
                    Name = dbp.Name,
                    UserId = dbp.UserId,
                    Tasks = dbts
                        .Where(dbt => dbt.Project == dbp.Id)
                        .Select(dbt => new NozzyTask()
                        {
                            Id = dbt.Id,
                            Completed = dbt.Completed,
                            Title = dbt.Title
                        })
                };

                projects.Add(project);
            }
            return projects;
        }

    public async Task<NozzyTask> SingleTask(long taskId, long userId)
    {
        //Conn.QueryAsync<DbTask>("")
        throw new NotImplementedException();
    }

    public Task<NozzyTask> CreateTask(NozzyTask task)
    {
        throw new NotImplementedException();
    }

    public Task SetTaskCompletion(long taskId, long userId, bool completion)
    {
        throw new NotImplementedException();
    }

    public Task<Project> CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task CreateOrSetAuthToken(string sub, string email, string authToken)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserFromAuthToken(string authToken)
    {
        throw new NotImplementedException();
    }
}
}