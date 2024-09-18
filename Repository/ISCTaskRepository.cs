using SecretClientTasksBackend.Models;
using System;

namespace SecretClientTasksBackend.Repository
{
    public interface ISCTaskRepository
    {
        Task<IEnumerable<SCTask>> GetSCTasks();

        Task<SCTask> GetSCTaskByID(long scTaskID);

        Task<bool> InsertSCTask(SCTask scTask);

        Task<bool> UpdateSCTask(long id, SCTask scTask);

        Task<bool> DeleteSCTask(long id);

        Task<bool> SaveUserTasks(string name, string email, List<long> tasks);
    }
}
