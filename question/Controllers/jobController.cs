using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Identity.Client;
using question.Models;
using question.repository;

namespace question.Controllers
{
    [Authorize(Roles ="admin")]    
    public class jobController : Controller
    {
        private readonly Ijobrepo ijobrepo;

        public jobController(Ijobrepo ijobrepo)
        {
            this.ijobrepo = ijobrepo;
        }
        
       

        public IActionResult Index()
        {
            List<job> jobs = ijobrepo.all();
            return View(jobs);
        }
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult save(job job)
        {
            if(ModelState.IsValid)
            {
                ijobrepo.add(job);
                ijobrepo.save();
                return RedirectToAction ("Index");
            }
            return View("add ", job);
        }
        public IActionResult edit(int id)
        {
            job job = ijobrepo.get(id);
            return View (job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult update(int id , job job)
        {
            if (ModelState.IsValid)
            {
                job jobdb = ijobrepo.get(id);
              jobdb.title=job.title;
              jobdb.description=job.description;
              jobdb.location=job.location;
              jobdb.skills_required=job.skills_required;
              jobdb.company=job.company;
                ijobrepo.save();
              return RedirectToAction("index");
            }
            return View("edite", job);
        }

        public IActionResult delete (int id)
        {
            job job = ijobrepo.get(id);
            if (job != null)
            {
                ijobrepo.delete(id);
                ijobrepo.save();
                return RedirectToAction("Index");
            }
            return Content ("Error : not found ");

        }
    }
}
