using Event_Management.Data;
using Microsoft.AspNetCore.Mvc;
using Event_Management.Models;

namespace Event_Management.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly AppDbContext _context;
        public ParticipantsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var events = _context.Participants.ToList();
            return View(events);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = _context.Participants.FirstOrDefault(m => m.P_Id == id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Participant participantsItem)
        {
            _context.Participants.Add(participantsItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participantsItem = _context.Participants.Find(id);
            if (participantsItem == null)
            {
                return NotFound();
            }
            return View(participantsItem);
        }
        [HttpPost]
        public IActionResult Edit(Participant participantsItem)
        {
            _context.Participants.Update(participantsItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participantsItem = _context.Participants.FirstOrDefault(m => m.P_Id == id);
            if (participantsItem == null)
            {
                return NotFound();
            }

            return View(participantsItem);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var participantsItem = _context.Participants.Find(id);
            if (participantsItem == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participantsItem);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        private bool EventExists(int id)
        {
            return _context.Participants.Any(e => e.P_Id == id);
        }
    }
}
