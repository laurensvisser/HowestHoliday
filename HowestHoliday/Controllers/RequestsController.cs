using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HowestHoliday.Data;
using HowestHoliday.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HowestHoliday.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = null;

        public RequestsController(ApplicationDbContext context)
        {
            db = context;
        }

        [Route("")]
        [Route("[action]")]
        public IActionResult Index()
        {
            return View(db.Request.ToList());
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public IActionResult Add()
        {
            return View(new Request());
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public IActionResult Add(Request request)
        {
            if (request != null && ModelState.IsValid)
            {
                request.Requestor = User.Identity.Name;

                db.Request.Add(request);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(request);
            }
        }

        [Route("[action]/{id}")]
        public IActionResult View(int id)
        {
            Request request = db.Request.SingleOrDefault(r => r.RequestId == id);
            return View(request);
        }

        [Route("[action]/{id}")]
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Manage(int id)
        {
            Request request = db.Request.SingleOrDefault(r => r.RequestId == id);
            return View(request);
        }

        [Route("[action]/{id}")]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Manage(Request request)
        {
            if (request != null && ModelState.IsValid)
            {
                request.Manager = User.Identity.Name;

                db.Request.Update(request);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(request);
            }
        }
    }
}