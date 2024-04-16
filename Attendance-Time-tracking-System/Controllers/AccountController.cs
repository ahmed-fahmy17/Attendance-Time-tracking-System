﻿using Attendance_Time_tracking_System.Data;
using Attendance_Time_tracking_System.Models;
using Attendance_Time_tracking_System.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Attendance_Time_tracking_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly AttendanceSysDbContext db;
        public AccountController(AttendanceSysDbContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
           
            RedirectToAction("Login");
            return View();

            
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            // Check if the model is valid
            if(!ModelState.IsValid) {
                return View(model);
            }

            //authenticate the user
            var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            //check if the user exists in database or not
            if(user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
			//sign in the user

			//claim for every part of the user
            Claim claimEmail = new Claim(ClaimTypes.Email, user.Email);
            Claim claimRole = new Claim(ClaimTypes.Role, user.Role.ToString());
            Claim claimId = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
            

            ClaimsIdentity claimsIdentity1 = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity1.AddClaim(claimEmail);
            claimsIdentity1.AddClaim(claimRole);
            claimsIdentity1.AddClaim(claimId);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            claimsPrincipal.AddIdentity(claimsIdentity1);
            await HttpContext.SignInAsync(claimsPrincipal);
            var routeValues = new RouteValueDictionary {
                    { "id", user.Id }
            };
            return RedirectToAction("Profile", "User", routeValues);

        }
        
    }
}
