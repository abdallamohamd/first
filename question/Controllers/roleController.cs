using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using question.view_model;

namespace question.Controllers
{
    [Authorize (Roles ="admin")]
    public class roleController : Controller

    {
        private readonly RoleManager<IdentityRole> roleManager;

        public roleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult role()
        {
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> save(rolevm rolevm)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = rolevm.Role_Name;
               IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return RedirectToAction("Index","home");
                }
               foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("role", rolevm);
        }


    }
}
