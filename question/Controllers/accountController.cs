using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using question.Models;
using question.view_model;

namespace question.Controllers
{
   
    public class accountController : Controller
    {
        private readonly UserManager<applicant> userManager;
        private readonly SignInManager<applicant> signInManager;

        public accountController(UserManager<applicant> userManager,SignInManager<applicant> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult regester()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> save(regester_vm model)
        {
            if (ModelState.IsValid)
            {
                applicant applicant = new applicant();
                applicant.UserName = model.name;
                applicant.addrss = model.address;
                applicant.PhoneNumber = model.phone;
                applicant.birthdate = model.birhdate;
                applicant.PasswordHash = model.password;
                applicant.Email = model.Email;

                IdentityResult result = await userManager.CreateAsync(applicant, model.password);
                if (result.Succeeded)
                {
                   await signInManager.SignInAsync(applicant, false);
                    return RedirectToAction("jobs", "users");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("regester",model);
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> sinin(loginvm log)
        {
            if (ModelState.IsValid)
            {
                applicant applicant =
                                await userManager.FindByNameAsync(log.name);
                if (applicant != null)
                {
                  
                    bool found = await userManager.CheckPasswordAsync(applicant, log.password);
                    if (found)
                    {
                        await signInManager.SignInAsync(applicant, log.rember);
                        return RedirectToAction( "jobs","users");
                    }
                    ModelState.AddModelError("", "in valid name or password");
                }
            }
            return View("login", log);
        }


        public async Task <IActionResult> log_out()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // add admin 
        public IActionResult add()
        {
          return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> admin (regester_vm regester)
        {
            if(ModelState.IsValid)
            {
                applicant applicant = new applicant();
                applicant.UserName = regester.name;
                applicant.addrss = regester.address;
                applicant.PhoneNumber = regester.phone;
                applicant.PasswordHash= regester.password;
                applicant.birthdate = regester.birhdate;
                applicant.Email = regester.Email;

               IdentityResult result = await  userManager.CreateAsync(applicant, regester.password);
                if(result.Succeeded)
                {
                  await  userManager.AddToRoleAsync(applicant, "admin");
                  await  signInManager.SignInAsync(applicant, false);
                    return RedirectToAction("index", "home");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
             }
            return View("add", regester);
        }
 
       

    }
}
