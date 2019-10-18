using StudentProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models
{
    public interface ITaskRepository
    {
        MyTask GetTaskById(int id);
        IEnumerable<MyTask> GetTasksByUser(ApplicationUser user);
        MyTask AddTask(MyTask task, ApplicationUser user);
        MyTask UpdateTask(EditTaskViewModel task);
        MyTask DeleteTask(int id);
    }
}
