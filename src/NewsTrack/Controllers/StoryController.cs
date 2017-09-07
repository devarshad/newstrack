using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsTrack.Controllers
{
    public class StoryController : BaseController
    {

        // GET: /Story/5
        /// <summary>
        /// fetch the detail for a story
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            return PartialView();
        }

        // GET: Story/Create
        /// <summary>
        /// create a new story
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        /// <summary>
        /// save a new story
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Story/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Story/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Story/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Story/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
