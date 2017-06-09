using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class AlumnoSetsController : Controller
    {
        private ColegioEntities db = new ColegioEntities();

        
        // GET: AlumnoSets
        public async Task<ActionResult> Index()
        {
            return View(await db.AlumnoSets.ToListAsync());
            
        }

        // GET: AlumnoSets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoSet alumnoSet = await db.AlumnoSets.FindAsync(id);
            if (alumnoSet == null)
            {
                return HttpNotFound();
            }
            return View(alumnoSet);
        }

        // GET: AlumnoSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnoSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Legajo,Mail")] AlumnoSet alumnoSet)
        {
            if (ModelState.IsValid)
            {
                db.AlumnoSets.Add(alumnoSet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(alumnoSet);
        }

        // GET: AlumnoSets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoSet alumnoSet = await db.AlumnoSets.FindAsync(id);
            if (alumnoSet == null)
            {
                return HttpNotFound();
            }
            return View(alumnoSet);
        }

        // POST: AlumnoSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Legajo,Mail")] AlumnoSet alumnoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoSet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alumnoSet);
        }

        // GET: AlumnoSets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoSet alumnoSet = await db.AlumnoSets.FindAsync(id);
            if (alumnoSet == null)
            {
                return HttpNotFound();
            }
            return View(alumnoSet);
        }

        // POST: AlumnoSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AlumnoSet alumnoSet = await db.AlumnoSets.FindAsync(id);
            db.AlumnoSets.Remove(alumnoSet);
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
