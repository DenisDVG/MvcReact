using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MvcReact.Models;
using MvcReact.ViewModels;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace MvcReact.Controllers
{
    public class NoteController : Controller
    {
        // GET: NoteController
        public ActionResult Index()
        {
            
            List<Note> notes = new List<Note>();
            if (TempData.ContainsKey("noteStorage"))
            {
                notes = TempData.Get<List<Note>>("noteStorage");
            }
            var noteStorage = new List<NoteViewModel>();
            foreach (var item in notes)
            {
                var noteViewModel = new NoteViewModel()
                {
                    Id = item.Id,
                    Content = item.Content,
                    Title = item.Title,
                };
                noteStorage.Add(noteViewModel);
            }
            TempData.Put<List<Note>>("noteStorage", notes);
            return View(noteStorage);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(NoteViewModel note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Note> notes = new List<Note>();
                    if (TempData.ContainsKey("noteStorage"))
                    {
                        notes = TempData.Get<List<Note>>("noteStorage");
                    }
                        
                    notes.Add(new Note
                    {
                        Id = Guid.NewGuid(),
                        Title = note.Title,
                        Content = note.Content
                    });

                    TempData.Put<List<Note>>("noteStorage", notes);
                    return RedirectToAction("Index");
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }



    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
