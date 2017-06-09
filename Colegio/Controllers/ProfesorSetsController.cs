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
    public class ProfesorSetsController : Controller
    {
        private ColegioEntities db = new ColegioEntities();

        // GET: ProfesorSets
        public async Task<ActionResult> Index()
        {
            return View(await db.ProfesorSets.ToListAsync());
        }

        // GET: ProfesorSets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorSet profesorSet = await db.ProfesorSets.FindAsync(id);
            if (profesorSet == null)
            {
                return HttpNotFound();
            }
            return View(profesorSet);
        }

        // GET: ProfesorSets/Create
        public ActionResult Create()
        {
            //Traer todos los alumnos
            List<AlumnoSet> alus = new List<AlumnoSet>();
            alus = db.AlumnoSets.ToList();
            ViewBag.alumnos = alus;
            return View();
        }

        // POST: ProfesorSets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nombre,Telefono,Direccion,Mail")] ProfesorSet profesorSet,int[] alus )
        {


            if (ModelState.IsValid)
            {
                
                    foreach (var a in alus)
                    {
                        AlumnoSet alu = AlumnoSet.BuscarPorId(a);
                        db.Entry(alu).State = EntityState.Modified;
                        profesorSet.AlumnoSets.Add(alu);
                    }
                
                db.ProfesorSets.Add(profesorSet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(profesorSet);
        }

        // GET: ProfesorSets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorSet profesorSet = await db.ProfesorSets.FindAsync(id);
            if (profesorSet == null)
            {
                return HttpNotFound();
            }
            return View(profesorSet);
        }

        // POST: ProfesorSets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nombre,Telefono,Direccion,Mail")] ProfesorSet profesorSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesorSet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profesorSet);
        }

        // GET: ProfesorSets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfesorSet profesorSet = await db.ProfesorSets.FindAsync(id);
            if (profesorSet == null)
            {
                return HttpNotFound();
            }
            return View(profesorSet);
        }

        // POST: ProfesorSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProfesorSet profesorSet = await db.ProfesorSets.FindAsync(id);
            db.ProfesorSets.Remove(profesorSet);
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
