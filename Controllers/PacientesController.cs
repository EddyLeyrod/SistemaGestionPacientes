using SistemaGestionPacientes.Models;
using System.Data.Entity; // EF: Para EntityState y operaciones de base de datos
using System.Net;
using System.Threading.Tasks; //  EF: Para operaciones asíncronas
using System.Web.Mvc;

namespace SistemaGestionPacientes.Controllers
{
    public class PacientesController : Controller
    {
        //  EF: Instancia del DbContext para acceder a la base de datos
        private PacienteContext db = new PacienteContext();

        // GET: Pacientes - muestra la lista de pacientes
        public async Task<ActionResult> Index()
        {
            //  EF: ToListAsync() ejecuta la consulta y obtiene todos los pacientes
            return View(await db.Pacientes.ToListAsync());
        }

        // GET: Pacientes/Details/5 - ver detalles de un paciente específico
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            //  EF: FindAsync() ejecuta una consulta para buscar el paciente
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return RedirectToAction("NotFound","Error");
            }
            return View(paciente);
        }

        // GET: Pacientes/Create - muestra la vista para el formulario de creación
        public ActionResult Create()
        {
            return View(); 
        }

        // POST: Pacientes/Create - crea un nuevo paciente
        [HttpPost]
        [ValidateAntiForgeryToken] // Previene ataques de falsificación de solicitudes
        public async Task<ActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid) // Validación del modelo
            {
                //  EF: Add()  inserta el nuevo paciente en el contexto
                db.Pacientes.Add(paciente);
                //  EF: SaveChangesAsync() ejecuta el INSERT en la base de datos
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paciente); // Si el modelo no es válido, vuelve a mostrar el formulario con errores
        }

        // GET: Pacientes/Edit/n - muestra el formulario para editar un paciente existente
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //error si no hay id
            }
            //  EF: FindAsync() busca el paciente a editar
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5 - actualizar un paciente existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                //  EF: Marca el objeto como modificado para UPDATE
                db.Entry(paciente).State = EntityState.Modified;
                //  EF: SaveChangesAsync() ejecuta UPDATE en la base de datos
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5 - mostrar confirmación para eliminar un paciente
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  EF: FindAsync() busca el paciente a eliminar
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5 - ekiminar un paciente confirmado
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            //  EF: Remove() prepara el registro para DELETE
            db.Pacientes.Remove(paciente);
            //  EF: SaveChangesAsync() ejecuta el DELETE en la base de datos y guarda los cambios
            await db.SaveChangesAsync();
            return RedirectToAction("Index"); // redirige a la lista de pacientes después de eliminar
        }
    }
}