using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LHL_BaiKiemtraGiuKi.Models;

namespace LHL_BaiKiemtraGiuKi.Controllers
{
    public class LHLSVsController : Controller
    {
        private LHLK22CNT3Lesson07Entities1 db = new LHLK22CNT3Lesson07Entities1();

        // GET: LHLSVs
        public ActionResult LhlIndex()
        {
            var lHLSVs = db.LHLSVs.Include(l => l.LhlKHOA);
            return View(lHLSVs.ToList());
        }

        // GET: LHLSVs/Details/5
        public ActionResult LhlDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLSV lHLSV = db.LHLSVs.Find(id);
            if (lHLSV == null)
            {
                return HttpNotFound();
            }
            return View(lHLSV);
        }

        // GET: LHLSVs/Create
        public ActionResult LhlCreate()
        {
            ViewBag.LhlMaKH = new SelectList(db.LhlKHOAs, "LhlMaKH", "LhlTenKH");
            return View();
        }

        // POST: LHLSVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LhlCreate([Bind(Include = "LhlMaSV,LhlHoSv,LhlTenSV,LhlNgaySinh,LhlPhai,LhlPhone,LhlEmail,LhlMaKH")] LHLSV LHLSV)
        {
            if (ModelState.IsValid)
            {
                db.LHLSVs.Add(LHLSV);
                db.SaveChanges();
                return RedirectToAction("LhlIndex");
            }
            ViewBag.LhlMaKH = new SelectList(db.LhlKHOAs, "LhlMaKH", "LhlTenKH", LHLSV.LhlMaKH);
            return View(LHLSV);
        }

        // GET: LHLSVs/Edit/5
        public ActionResult LhlEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLSV lHLSV = db.LHLSVs.Find(id);
            if (lHLSV == null)
            {
                return HttpNotFound();
            }
            ViewBag.LhlMaKH = new SelectList(db.LhlKHOAs, "LhlMaKH", "LhlTenKH", lHLSV.LhlMaKH);
            return View(lHLSV);
        }

        // POST: LHLSVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LhlEdit([Bind(Include = "LhlMaSV,LhlHoSv,LhlTenSV,LhlNgaySinh,LhlPhai,LhlPhone,LhlEmail,LhlMaKH")] LHLSV lHLSV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lHLSV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LhlIndex");
            }
            ViewBag.LhlMaKH = new SelectList(db.LhlKHOAs, "LhlMaKH", "LhlTenKH", lHLSV.LhlMaKH);
            return View(lHLSV);
        }

        // GET: LHLSVs/Delete/5
        public ActionResult LhlDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LHLSV lHLSV = db.LHLSVs.Find(id);
            if (lHLSV == null)
            {
                return HttpNotFound();
            }
            return View(lHLSV);
        }

        // POST: LHLSVs/Delete/5
        [HttpPost, ActionName("LhlDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LhlDeleteConfirmed(string id)
        {
            LHLSV lHLSV = db.LHLSVs.Find(id);
            db.LHLSVs.Remove(lHLSV);
            db.SaveChanges();
            return RedirectToAction("LhlIndex");
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
