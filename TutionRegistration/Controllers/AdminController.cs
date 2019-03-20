using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutionRegistration.Models;
using TutionRegistration.ViewModels;

namespace TutionRegistration.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var batchData = _context.Batches.ToList();
            return View(batchData);
        }
       
        [Authorize]
        public ActionResult NewBatch()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewBatchAddToDatabase(Batches batches)
        {
            _context.Batches.Add(batches);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //batch delete
        [Authorize]
        public ActionResult Delete(int id)
        {
            var deleteBatch = _context.Batches.Find(id);
            Batches batches = deleteBatch;
            if (deleteBatch == null)
            {
                return HttpNotFound();
            }

            _context.Batches.Remove(batches);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var batch = _context.Batches.FirstOrDefault(b => b.Id == id);
            if(batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        [HttpPost]
        public ActionResult Edit(int id, Batches batches)
        {
            var batch = _context.Batches.Find(id);
            if(batch == null)
            {
                return HttpNotFound();
            }

            batch.Name = batches.Name;
            batch.Fees = batches.Fees;
            batch.Duration = batches.Duration;
            batch.Timing = batches.Timing;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var batch = _context.Batches.Find(id);
            if(batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        
    }
}