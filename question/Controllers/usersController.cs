using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using question.Models;
using question.repository;
using System.Security.Claims;

namespace question.Controllers
{
    [Authorize]
    public class usersController : Controller
    {
        private readonly Iapplicationrepo apprepo;
        private readonly Ijobrepo jobrepo;

        public usersController(Iapplicationrepo apprepo,Ijobrepo jobrepo)
        {
            this.apprepo = apprepo;
            this.jobrepo = jobrepo;
        } 



        public IActionResult jobs( string job)
        {
            List<job> jobs = jobrepo.all();
            if (!string.IsNullOrEmpty(job))
            {
                jobs = jobs.Where(x => x.title.Contains(job)).ToList();
            }
            return View(jobs);
        }
       
         public IActionResult notes()
        {
            List<application> applications = apprepo.all();
            return View(applications);
        }
       
    }
}
