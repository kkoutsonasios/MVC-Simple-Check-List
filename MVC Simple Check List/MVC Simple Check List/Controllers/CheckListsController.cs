using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Simple_Check_List.Models;

namespace MVC_Simple_Check_List.Controllers
{
    public class CheckListsController : Controller
    {
        private CheckListDBContext db = new CheckListDBContext();

        // GET: CheckLists
        public async Task<ActionResult> Index()
        {
            return View(await db.CheckLists.ToListAsync());
        }

        // GET: CheckLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckList checkList = await db.CheckLists.FindAsync(id);
            if (checkList == null)
            {
                return HttpNotFound();
            }
            return View(checkList);
        }

        // GET: CheckLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description,CreationDate")] CheckList checkList)
        {
            if (ModelState.IsValid)
            {
                db.CheckLists.Add(checkList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(checkList);
        }

        // GET: CheckLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckList checkList = await db.CheckLists.FindAsync(id);
            if (checkList == null)
            {
                return HttpNotFound();
            }
            return View(checkList);
        }

        // POST: CheckLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description,CreationDate")] CheckList checkList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(checkList);
        }

        // GET: CheckLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckList checkList = await db.CheckLists.FindAsync(id);
            if (checkList == null)
            {
                return HttpNotFound();
            }
            return View(checkList);
        }

        // POST: CheckLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CheckList checkList = await db.CheckLists.FindAsync(id);
            db.CheckLists.Remove(checkList);
            await db.SaveChangesAsync();
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
