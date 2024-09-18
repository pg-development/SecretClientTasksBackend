using SecretClientTasksBackend.DBContexts;
using SecretClientTasksBackend.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SecretClientTasksBackend.Repository
{
    public class SCTaskRepository : ISCTaskRepository
    {
        private readonly SCTasksDBContext _dbContext;

        public SCTaskRepository(SCTasksDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SCTask>> GetSCTasks()
        {
            return await _dbContext.SCTasks.ToListAsync();
        }

        public async Task<bool> DeleteSCTask(long id)
        {
            try
            {
                var taskToRemove = await _dbContext.SCTasks.FindAsync(id);
                if (taskToRemove == null) return false;

                _dbContext.SCTasks.Remove(taskToRemove);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<SCTask> GetSCTaskByID(long scTaskID)
        {
            //TODO: create a static field in model that will be returned when 404
            return await _dbContext.SCTasks.FindAsync(scTaskID);
        }

        public async Task<bool> SaveUserTasks(string name, string email, List<long> userTasks)
        {
            try
            {
                foreach (long taskId in userTasks)
                {
                    SCTask? task = await _dbContext.SCTasks.FindAsync(taskId);
                    if (task == null) continue;

                    if (String.IsNullOrWhiteSpace(task.SCEmails))
                        task.SCEmails += $"({name}) {email}";
                    else if (!task.SCEmails.Contains(email))
                        task.SCEmails += $",({name}) {email}";
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> InsertSCTask(SCTask scTask)
        {
            try
            {
                await _dbContext.SCTasks.AddAsync(scTask);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateSCTask(long id, SCTask scTask)
        {
            try
            {
                var toMod = await _dbContext.SCTasks.FindAsync(id);
                if (toMod == null) return false;

                toMod.Address = scTask.Address;
                toMod.Gratification = scTask.Gratification;
                toMod.EndDate = scTask.EndDate;
                toMod.StartDate = scTask.StartDate;
                toMod.City = scTask.City;
                toMod.Description = scTask.Description;
                toMod.Name = scTask.Name;
                toMod.WaitingPeriod = scTask.WaitingPeriod;
                toMod.Voivodeship = scTask.Voivodeship;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
