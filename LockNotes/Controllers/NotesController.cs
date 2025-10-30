using Microsoft.AspNetCore.Mvc;
using LockNotes.Models;

namespace LockNotes.Controllers
{
    public class NotesController : Controller
    {
        // In-memory note list (will reset when you stop the app)
        private static List<Note> _notes = new();

        // GET: /Notes
        public IActionResult Index()
        {
            return View(_notes);
        }

        // POST: /Notes/Add
        [HttpPost]
        public IActionResult Add(string title, string content)
        {
            var note = new Note
            {
                Id = _notes.Count + 1,
                Title = title,
                Content = content
            };

            _notes.Add(note);
            return RedirectToAction("Index");
        }
    }
}
