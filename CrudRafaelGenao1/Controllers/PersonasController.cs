using CrudRafaelGenao1.Data;
using CrudRafaelGenao1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRafaelGenao1.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index    
        public IActionResult Index()
        {
            IEnumerable<Persona> ListPersonas = _context.Persona;

            return View(ListPersonas);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            if(ModelState.IsValid)
            {
                _context.Persona.Add(persona);
                _context.SaveChanges();

                TempData["mensaje"] = "La persona se ha creado de manera exitosa en el sistema";
                return RedirectToAction("Index");
            }

            return View();
        }

        //http get edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener la persona    
            var persona = _context.Persona.Find(id);

            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        //http Post Edit
        [HttpPost]
        public IActionResult Edit(Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Persona.Update(persona);
                _context.SaveChanges();

                TempData["mensaje"] = "La persona se ha actualizado de manera exitosa en el sistema";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener persona
            var persona = _context.Persona.Find(id);

            if (persona ==  null)
            {
                return NotFound();
            }
            return View(persona);
        }

        //http post delete
        [HttpPost]
        public IActionResult DeletePersona(int? id)
        {
            //obtener persona
            var persona = _context.Persona.Find(id);

            if(persona == null)
            {
                return NotFound();
            }
            
                _context.Persona.Remove(persona);
                _context.SaveChanges();

                TempData["mensaje"] = "La persona se ha eliminado de manera exitosa en el sistema";
                return RedirectToAction("Index");
            
        }
    }

}
