using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using StudentProject.Models.ViewModels;

namespace StudentProject.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        private readonly ITaskRepository taskRepository;
        
        public TaskController(UserManager<ApplicationUser> userManager, ITaskRepository taskRepository)
        {
            UserManager = userManager;
            this.taskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(MyTask mytask)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(User);
                taskRepository.AddTask(mytask, user);
            }
            return RedirectToActionPermanent("MyTasks");
        }

        [HttpPost]
        public IActionResult DeleteTask(int Id)
        {
            taskRepository.DeleteTask(Id);
            return RedirectToAction("MyTasks");
        }

        [HttpGet]
        public IActionResult EditTask(int Id)
        {
            var task = taskRepository.GetTaskById(Id);
            var model = new EditTaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                User = task.User
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditTask(EditTaskViewModel model)
        {
            var task = taskRepository.UpdateTask(model);
            return RedirectToAction("MyTasks");
        }

        public async Task<IActionResult> MyTasks()
        {
            var user = await UserManager.GetUserAsync(User);
            var myTasks = taskRepository.GetTasksByUser(user);
            return View(myTasks);
        }

    }
}