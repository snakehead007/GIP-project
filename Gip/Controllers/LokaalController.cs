using Gip.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gip.Controllers
{
    public class LokaalController : Controller
    {
        private gipDatabaseContext db = new gipDatabaseContext();
        // GET
        [HttpGet]
        [Route("lokaal")]
        public ActionResult Index()
        {
            try
            {
                //var gebouwlst = new List<string>();
                var qry = from d in db.Room
                    orderby d.Gebouw, d.Verdiep, d.Nummer
                    select d;

                if (TempData["error"] != null) {
                    ViewBag.error = TempData["error"].ToString();
                }
                if (ViewBag.error == null || !ViewBag.error.Equals("addError") && !ViewBag.error.Equals("addGood") && !ViewBag.error.Equals("deleteError") && !ViewBag.error.Equals("deleteGood") && !ViewBag.error.Equals("editError") && !ViewBag.error.Equals("editGood"))
                {
                    ViewBag.error = "indexLokaalGood";
                }
                return View(qry);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.error = "indexLokaalError";
                return RedirectToAction("Index", "Home");
            }
        }

        // POST /add/lokaal
        [HttpPost]
        [Route("lokaal/add")]
        public ActionResult Add(string gebouw, int verdiep, string nummer, string type, int capaciteit, string middelen )
        {
            try
            {
                Room room = new Room();
                room.Gebouw = gebouw.ToUpper();
                room.Verdiep = verdiep;
                room.Nummer = nummer;
                room.Type = type;
                room.Capaciteit = capaciteit;
                room.Middelen = middelen;
                db.Room.Add(room);
                
                db.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                TempData["error"] = "addError";
                return RedirectToAction("Index", "Lokaal");
            }
            TempData["error"] = "addGood";
            return RedirectToAction("Index", "Lokaal");
        }
        
        [HttpGet]
        [Route("lokaal/add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("lokaal/delete")]
        public ActionResult Delete(string lokaalId)
        {
            if (lokaalId == null || lokaalId.Trim().Equals(""))
            {
                TempData["error"] = "deleteError";
                return RedirectToAction("Index", "Lokaal");
            }
            lokaalId = lokaalId.Trim() + " ";
            string gebouw = lokaalId.Substring(0, 1);
            int verdieping = int.Parse(lokaalId.Substring(1,1));
            string nummer = lokaalId.Substring(2, (lokaalId.Length-2));
            
            Room room = db.Room.Find(gebouw,verdieping,nummer);

            if (room == null)
            {
                TempData["error"] = "deleteError";
                return RedirectToAction("Index", "Lokaal");
            }

            try
            {
                db.Room.Remove(room);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                TempData["error"] = "deleteError";
                return RedirectToAction("Index", "Lokaal");
            }
            TempData["error"] = "deleteGood";
            return RedirectToAction("Index", "Lokaal");
        }

        [HttpGet]
        [Route("lokaal/edit")]
        public ActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        [Route("lokaal/edit")]
        public ActionResult Edit(string lokaalId, string gebouw, int verdiep, string nummer, string type, int capaciteit, string middelen)
        {
            try
            {
                gebouw = gebouw.ToUpper();
                if (lokaalId == null || lokaalId.Trim().Equals(""))
                {
                    TempData["error"] = "editError";
                    return NotFound();
                }

                lokaalId = lokaalId.Trim() + " ";
                string gebouwId = lokaalId.Substring(0, 1);
                int verdieping = int.Parse(lokaalId.Substring(1, 1));
                string nummerOld = lokaalId.Substring(2, (lokaalId.Length - 2));

                Room room = db.Room.Find(gebouwId, verdieping, nummerOld);
                Delete(lokaalId);

            
                room.Gebouw = gebouw.Trim();
                room.Verdiep = verdiep;
                room.Nummer = nummer;
                room.Type = type;
                room.Capaciteit = capaciteit;
                room.Middelen = middelen;                    
                db.Room.Add(room);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["error"] = "editError";
                return RedirectToAction("Index", "Lokaal");
            }
            TempData["error"] = "editGood";
            return RedirectToAction("Index", "Lokaal");
        }
    }
}