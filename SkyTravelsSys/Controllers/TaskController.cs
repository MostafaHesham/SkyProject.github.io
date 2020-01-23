using SkyTravelsSys.Enums;
using SkyTravelsSys.Models;
using SkyTravelsSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyTravelsSys.Controllers
{
    public class TaskController : Controller
    {
        private SkyTravelsDBEntities1 db = new SkyTravelsDBEntities1();

        // GET: /Task/Generate
        [HttpGet]
        public ActionResult GenerateTask()
        {
            TaskViewModel taskView = new TaskViewModel();
            taskView.Days = new List<DropDownListModel>();

            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Saturday, Name = DaysOfWeek.Saturday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Sunday, Name = DaysOfWeek.Sunday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Monday, Name = DaysOfWeek.Monday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Tuesday, Name = DaysOfWeek.Tuesday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Wednesday, Name = DaysOfWeek.Wednesday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Thursday, Name = DaysOfWeek.Thursday.ToString() });
            taskView.Days.Add(new DropDownListModel { Id = (int)DaysOfWeek.Friday, Name = DaysOfWeek.Friday.ToString() });
            taskView.Captain = new List<DropDownListModel>();
            var captainsEnt = db.CrewTbls.Where(x => x.Role == "CPT").ToList();
            foreach (var capt in captainsEnt)
            {
                taskView.Captain.Add(new DropDownListModel { Id = capt.ID, Name = capt.Name });
            }
            var FirstOfficersEnt = db.CrewTbls.Where(x => x.Role == "FO").ToList();
            taskView.FirstOfficer = new List<DropDownListModel>();
            foreach (var fo in FirstOfficersEnt)
            {
                taskView.FirstOfficer.Add(new DropDownListModel { Id = fo.ID, Name = fo.Name });
            }
            return View(taskView);
        }

        // POST: /Task/Generate
        [HttpPost]
        public ActionResult GenerateTask(TaskViewModel taskView)
        {
            OperationTbl tbl = new OperationTbl();
            tbl.AirportFrom = taskView.AirportFrom;
            tbl.AirportTo = taskView.AirportTo;
            tbl.Cabin = taskView.CabindName;
            tbl.CaptainID = Convert.ToInt32(taskView.CaptinId);
            tbl.Client = taskView.Client;
            tbl.FirstOfficerID = Convert.ToInt32(taskView.firstOfficerId);
            tbl.FlightNumber = taskView.FlightNumber;
            tbl.Landing = taskView.Landing;
            tbl.OperationDate = taskView.Calender;
            tbl.OperationDay = Convert.ToInt32(taskView.DayId);
            tbl.PAX = taskView.Pax;
            tbl.REG = taskView.Reg;
            tbl.TakeOFF = taskView.TakeOff;

            db.OperationTbls.Add(tbl);
            db.SaveChanges();
            return RedirectToAction("GenerateTask");

        }

        [HttpGet]
        public ActionResult GetAllTasks()
        {
            var operationsList = db.OperationTbls.ToList();
            List<TaskViewModel> taskViewModels = new List<TaskViewModel>();
            foreach (OperationTbl tbl in operationsList)
            {
                TaskViewModel task = new TaskViewModel();
                task.AirportFrom = tbl.AirportFrom;
                task.AirportTo = tbl.AirportTo;
                task.CabindName = tbl.Cabin;
                task.Calender = (DateTime)tbl.OperationDate;
                task.CaptinName = db.CrewTbls.FirstOrDefault(x => x.ID == tbl.CaptainID).Name;
                task.firstOfficerName = db.CrewTbls.FirstOrDefault(x => x.ID == tbl.FirstOfficerID).Name;
                task.Client = tbl.Client;
                task.DayName = ((DaysOfWeek)tbl.OperationDay).ToString();
                task.Reg = tbl.REG;
                task.FlightNumber = tbl.FlightNumber;
                task.TakeOff = tbl.TakeOFF;
                task.Landing = tbl.Landing;
                task.Pax = (int)tbl.PAX;
                taskViewModels.Add(task);

            }
            return View(taskViewModels);
            //List<TaskViewModel> models = new List<TaskViewModel>();
            //TaskViewModel t1 = new TaskViewModel();
            //t1.DayName = "Sunday";
            //t1.Calender = DateTime.Now;
            //t1.Reg = "SMU";
            //t1.FlightNumber = "12f";
            //t1.AirportFrom = "cairo";
            //t1.AirportTo = "giza";
            //t1.Landing = "02:02";
            //t1.TakeOff = "03:00";
            //t1.Pax = 2;
            //t1.CaptinName = "mahmoud";
            //t1.firstOfficerName = "ali";
            //t1.CabindName = "sara";
            //t1.Client = "skyUser";
            //models.Add(t1);
            //TaskViewModel t2 = new TaskViewModel();
            //t2.DayName = "Sunday";
            //t2.Calender = DateTime.Now;
            //t2.Reg = "SMU";
            //t2.FlightNumber = "12f";
            //t2.AirportFrom = "cairo";
            //t2.AirportTo = "giza";
            //t2.Landing = "02:02";
            //t2.TakeOff = "03:00";
            //t2.Pax = 2;
            //t2.CaptinName = "mahmoud";
            //t2.firstOfficerName = "ali";
            //t2.CabindName = "sara";
            //t2.Client = "skyUser";
            //models.Add(t2);
            //   return View(models);
        }


    }
}