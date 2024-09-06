using Microsoft.AspNetCore.Mvc;
using watchyproject.Models;


namespace watchyproject.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı doğrulama işlemleri burada yapılacak
                // Eğer doğrulama başarılı olursa, kullanıcıyı yönlendirebilirsiniz.
                return RedirectToAction("Index", "Home");
            }

            // Eğer doğrulama başarısız olursa, aynı sayfayı tekrar gösterin
            return View(model);
        }
    }
}
