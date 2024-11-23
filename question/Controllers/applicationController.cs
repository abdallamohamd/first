using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using question.Models;
using question.repository;
using System.Security.Claims;

namespace question.Controllers
{
    [Authorize(Roles ="admin")]
    public class applicationController : Controller
    {
        private readonly Iapplicationrepo repo;
        private readonly Ijobrepo jobrepo;

        public applicationController(Iapplicationrepo repo,Ijobrepo jobrepo)
        {
            this.repo = repo;
            this.jobrepo = jobrepo;
        }
        
        public IActionResult index()
        {
            List<application> applications = repo.all(); //context.applications.Include(x =>x.applicant ).Include(x=>x.job).ToList();
            
            return View(applications);
        }
        public IActionResult add(int id)
        {
            job job = jobrepo.get(id);     //context.jobs.FirstOrDefault(x => x.id == id);
            application application = new application();

            if (User.Identity.IsAuthenticated == true)
            {
                Claim claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string uid = claim.Value;

                application.application_date = DateTime.Now;
                application.job_id = job.id;
                application.status = " not read ";
                application.applicant_id = uid;

                repo.add(application);
                repo.save();
                return RedirectToAction("note","users",application.id);
            }
            return Content("not found");
        }

        public IActionResult edite(int id)
        {
            application application = repo.Get(id);
            return View(application);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult update(application application,int id)
        {
            if(ModelState.IsValid)
            {
                application applicationdb = repo.Get(id);
                applicationdb.status = application.status;
                repo.save();
                return RedirectToAction("index");
            }
            return View("edite", application);
        }

        public IActionResult remove (int id)
        {
            application application = repo.Get(id);
            if(application != null)
            {
                repo.delete(id);
                repo.save();
                return RedirectToAction("index");
            }
            return Content("not found");
        }


    }
}
