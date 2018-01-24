using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecExerciseMosaic.Models;

namespace TecExerciseMosaic.Controllers
{
    public class TaskListController : Controller
    {
        // GET: TaskList
        public ActionResult TasksList()
        {
            List<Tasks> tasksList = new List<Tasks>();
            if (Session["tasksList"] != null)
            {
                tasksList = (List<Tasks>)Session["tasksList"];
            }

            return View(tasksList);
        }

        [HttpGet]
        public ActionResult AddTask(string Description)
        {
            List<Tasks> tasksList = new List<Tasks>();

            Tasks task = new Tasks()
            {
                Selected = false,
                Description = Description
            };

            if (Session["tasksList"] != null)
            {

                tasksList = (List<Tasks>)Session["tasksList"];
                Tasks tareaCad = new Tasks();
                if (tasksList.Any())
                {
                    tareaCad = tasksList.Last();
                    task.TaskId = tareaCad.TaskId + 1;
                }
                else
                {
                    task.TaskId = 0;
                }

                tasksList.Add(task);
            }
            else
            {
                task.TaskId = 1;
                tasksList.Add(task);
            }

            Session["tasksList"] = tasksList;
            return View("TasksList", tasksList);
        }

        [HttpGet]
        public ActionResult DeleteTask(int id)
        {
            List<Tasks> tasksList = (List<Tasks>)Session["tasksList"];

            tasksList.Remove(tasksList.Where(x => x.TaskId == id).FirstOrDefault());

            Session["tasksList"] = tasksList;

            return View("TasksList", tasksList);
        }

        [HttpGet]
        public ActionResult MarkTask(int id)
        {
            List<Tasks> tasksList = (List<Tasks>)Session["tasksList"];

            var index = tasksList.FindIndex(x => x.TaskId == id);
            if (tasksList[index].Selected)
                tasksList[index].Selected = false;
            else
                tasksList[index].Selected = true;

            Session["tasksList"] = tasksList;

            return View("TasksList", tasksList);

        }
    }
}