using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumptionPredictor.Controllers
{
    public class PredictionController : Controller
    {
        // GET: PredictionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PredictionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PredictionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PredictionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PredictionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PredictionController/Edit/5
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

        // GET: PredictionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PredictionController/Delete/5
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
}
