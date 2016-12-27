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
    public class CheckListItemsController : Controller
    {
        private CheckListDBContext db = new CheckListDBContext();

        // GET: CheckListItems
        public async Task<ActionResult> Index()
        {
            return View(await db.CheckListItems.ToListAsync());
        }

        // GET: CheckListItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckListItem checkListItem = await db.CheckListItems.FindAsync(id);
            if (checkListItem == null)
            {
                return HttpNotFound();
            }
            return View(checkListItem);
        }

        // GET: CheckListItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckListItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Text,state,CreationDate,StatusChangedDate")] CheckListItem checkListItem)
        {
            if (ModelState.IsValid)
            {
                db.CheckListItems.Add(checkListItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(checkListItem);
        }

        // GET: CheckListItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckListItem checkListItem = await db.CheckListItems.FindAsync(id);
            if (checkListItem == null)
            {
                return HttpNotFound();
            }
            return View(checkListItem);
        }

        // POST: CheckListItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Text,state,CreationDate,StatusChangedDate")] CheckListItem checkListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkListItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(checkListItem);
        }

        // GET: CheckListItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckListItem checkListItem = await db.CheckListItems.FindAsync(id);
            if (checkListItem == null)
            {
                return HttpNotFound();
            }
            return View(checkListItem);
        }

        // POST: CheckListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CheckListItem checkListItem = await db.CheckListItems.FindAsync(id);
            db.CheckListItems.Remove(checkListItem);
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
