using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkyTravelsSys.Enums;
using SkyTravelsSys.Models;
using SkyTravelsSys.ViewModels;

namespace SkyTravelsSys.Controllers
{
    public class OperationsController : Controller
    {
        private SkyTravelsDBEntities1 db = new SkyTravelsDBEntities1();

        // GET: Operations
        public ActionResult Index()
        {
            var operationsList = db.OperationTbls.ToList();
            List<TaskViewModel> taskViewModels = new List<TaskViewModel>();
            TaskViewModel task = new TaskViewModel();
            foreach (OperationTbl tbl in operationsList)
            {
                task.AirportFrom = tbl.AirportFrom;
                task.AirportTo = tbl.AirportTo;
                task.CabindName = tbl.Cabin;
                task.Calender = (DateTime)tbl.OperationDate;
                task.CaptinName = db.CrewTbls.FirstOrDefault(x => x.ID == tbl.CaptainID).Name;
                task.firstOfficerName = db.CrewTbls.FirstOrDefault(x => x.ID == tbl.FirstOfficerID).Name;
                //task.CabindName = db.CrewTbls.FirstOrDefault(x => x.ID == tbl.CaptainID).Name;
                task.Client = tbl.Client;
                task.DayName = ((DaysOfWeek)tbl.OperationDay).ToString();
                task.Reg = tbl.REG;
                task.FlightNumber = tbl.FlightNumber;
                task.TakeOff= tbl.TakeOFF;
                task.Landing= tbl.Landing;
                task.Pax= (int)tbl.PAX;
            }
            return View();
        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationTbl operationTbl = db.OperationTbls.Find(id);
            if (operationTbl == null)
            {
                return HttpNotFound();
            }
            return View(operationTbl);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel taskView)
        {
            OperationTbl tbl = new OperationTbl();
            tbl.AirportFrom  = taskView.AirportFrom ;
            tbl.AirportTo = taskView.AirportTo ;
            tbl.Cabin = taskView.CabindName ;
            tbl.CaptainID = Convert.ToInt32(taskView.CaptinId);
            tbl.Client = taskView.Client ;
            tbl.FirstOfficerID = Convert.ToInt32(taskView.firstOfficerId) ;
            tbl.FlightNumber = taskView.FlightNumber ;
            tbl.Landing = taskView.Landing ;
            tbl.OperationDate = taskView.Calender ;
            tbl.OperationDay = Convert.ToInt32(taskView.DayId) ;
            tbl.PAX = taskView.Pax ;
            tbl.REG = taskView.Reg ;
            tbl.TakeOFF = taskView.TakeOff ;
            if (ModelState.IsValid)
            {
                db.OperationTbls.Add(tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationTbl operationTbl = db.OperationTbls.Find(id);
            if (operationTbl == null)
            {
                return HttpNotFound();
            }
            return View(operationTbl);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OperationDay,OperationDate,REG,FlightNumber,AirportFrom,AirportTo,TakeOFF,Landing,PAX,CaptainID,FirstOfficerID,Cabin,Client,IsCanceled")] OperationTbl operationTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operationTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operationTbl);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationTbl operationTbl = db.OperationTbls.Find(id);
            if (operationTbl == null)
            {
                return HttpNotFound();
            }
            return View(operationTbl);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperationTbl operationTbl = db.OperationTbls.Find(id);
            db.OperationTbls.Remove(operationTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
