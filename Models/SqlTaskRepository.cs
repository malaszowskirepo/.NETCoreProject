using StudentProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models
{
    public class SqlTaskRepository : ITaskRepository
    {
        public SqlTaskRepository(AppDbContext context)
        {
            Context = context;
        }

        public AppDbContext Context { get; }


        public MyTask AddTask(MyTask task, ApplicationUser user)
        {
            task.User = user;
            Context.Tasks.Add(task);
            Context.SaveChanges();
            return task;
        }

        public MyTask DeleteTask(int id)
        {
            MyTask task = GetTaskById(id);
            Context.Remove(task);
            Context.SaveChanges();
            return task;
        }

        public MyTask GetTaskById(int id)
        {
            return Context.Tasks.Find(id);
        }

        public IEnumerable<MyTask> GetTasksByUser(ApplicationUser user)
        {
            return Context.Tasks.Where(task => task.User.Equals(user));
        }

        public MyTask UpdateTask(EditTaskViewModel task)
        {
            var myTask = GetTaskById(task.Id);
            myTask.Name = task.Name;
            myTask.Description = task.Description;
            Context.SaveChanges();
            return myTask;
        }
    }
}
