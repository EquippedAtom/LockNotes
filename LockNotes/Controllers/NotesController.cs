using Microsoft.AspNetCore.Mvc;
using LockNotes.Models;
using LockNotes.Data;
using System.Linq;

namespace LockNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly LockNotesContext _context;

        public NotesController(LockNotesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notes = _context.Notes.ToList();
            return View(notes);
        }

        [HttpPost]
        public IActionResult Add(string title, string content)
        {
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
            {
                var note = new Note { Title = title, Content = content };
                _context.Notes.Add(note);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string title, string content)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                note.Title = title;
                note.Content = content;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
