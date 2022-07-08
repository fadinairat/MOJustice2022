using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOE.Models;
using MOE.Helpers;

namespace MOE.Areas.Control.Controllers
{
    
    [Area("Control")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        // GET: Control/Users
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Users.Where(a => a.Deleted == 0).Include(u => u.Group).Include(u => u.Language);
            return View(await dataContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            if (HttpContext.Session.GetString("id") != "")
            {
                var user = await _context.Users.FindAsync(int.Parse(HttpContext.Session.GetString("id") ?? "1"));
                return View(user);
            }
            else
            {
                return NotFound();
            }            
        }

        [Authorize]
        [HttpPost("Profile")]
        public async Task<IActionResult> Profile(string fullname,string nickname,string password, string confirm_password, string email)
        {
            if (HttpContext.Session.GetString("id") != "")
            {
                var user = await _context.Users.FindAsync(int.Parse(HttpContext.Session.GetString("id") ?? "1"));
                user.Nickname = nickname;
                if(password!="******" && password != "")
                {
                    user.Password = Encryption.Encrypt(password, true);
                }
                
                user.Email = email;

                await _context.SaveChangesAsync();
                TempData["success"] = "Profile updated successfully...";
                return View(user);
                //}
                //else
                //{
                //    TempData["error"] = "Cannot edit profile! Validation Error...";
                //}

                return View("profile");
            }
            else
            {
                return NotFound();
            }
        }



        //string ReturnUrl
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["error"] = TempData["error"];
            ViewData["redirectUrl"] = ReturnUrl;
            return View();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password, string redirectUrl)
        {
            ViewData["redirectUrl"] = redirectUrl;
            
            var user = _context.Users.FirstOrDefault(u => u.Email == username);
            if(user != null) //Login Success
            {
                if(Encryption.Decrypt(user.Password, true) == password)
                {
                    //ViewBag.Msg = "Login success...";
                    var claims = new List<Claim>();

                    claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                    claims.Add(new Claim(ClaimTypes.Name, user.Fullname));
                    claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim(ClaimTypes.GroupSid, user.GroupId.ToString()));
                    claims.Add(new Claim("username", username));
                    claims.Add(new Claim("nickname", user.Nickname));
                    claims.Add(new Claim("lastLogin", user.LastLogin.ToString()));
                    claims.Add(new Claim("id", user.Id.ToString()));

                    HttpContext.Session.SetString("id", user.Id.ToString());
                    HttpContext.Session.SetInt32("group_id", (int)user.GroupId);
                    HttpContext.Session.SetString("username", user.LoginName);
                    HttpContext.Session.SetString("email", user.Email);
                    HttpContext.Session.SetString("lastLogin", user.LastLogin.ToString());
                    HttpContext.Session.SetString("nickname", user.Nickname);

                    if (user.GroupId == 1)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    //

                    user.LastLogin = DateTime.Now;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrinciple);


                    return Redirect(System.Net.WebUtility.UrlDecode(redirectUrl));
                }
                else
                {
                    ViewBag.Msg = "Wrong password...";
                }
            }
            else
            {
                ViewBag.Msg = "Wrong username or password...";
            }

            //if (username == "fadi" && password == "fadi")
            //{
            //    ViewBag.Msg = "Wrong username or password...";
            //    return View();
            //}
            
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Forget()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        // GET: Control/Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Group)
                .Include(u => u.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Control/Users/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups.Where(a => a.Deleted == 0), "Id", "Name");
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted==0), "Id", "Name");
            return View();
        }

        // POST: Control/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fullname,Nickname,GroupId,LoginName,Password,Email,LangId,LastLogin,AddDate,Active,Deleted")] User user)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("id") != "")
                {
                    user.AddedBy = int.Parse(HttpContext.Session.GetString("id") ?? "1");
                }
                else user.AddedBy = null;
               
                user.Password = Encryption.Encrypt(user.Password, true);
                user.AddDate = DateTime.Now;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups.Where(a => a.Deleted == 0), "Id", "Name", user.GroupId);
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", user.LangId);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Control/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups.Where(a => a.Deleted == 0), "Id", "Name", user.GroupId);
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", user.LangId);
            return View(user);
        }

        // POST: Control/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fullname,Nickname,GroupId,LoginName,Password,Email,LangId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    User userToUpdate = _context.Users.Find(id);
                    userToUpdate.Fullname = user.Fullname;
                    userToUpdate.Nickname = user.Nickname;
                    userToUpdate.GroupId = user.GroupId;
                    userToUpdate.LoginName = user.LoginName;
                    userToUpdate.Email = user.Email;
                    userToUpdate.LangId = user.LangId;

                    if(user.Password!="" && user.Password != "******")
                    {
                        userToUpdate.Password = Encryption.Encrypt(user.Password, true);
                    }

                    _context.Update(userToUpdate);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups.Where(a => a.Deleted == 0), "Id", "Name", user.GroupId);
            ViewData["LangId"] = new SelectList(_context.Languages.Where(a => a.Deleted == 0), "Id", "Name", user.LangId);
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Control/Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Group)
                .Include(u => u.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // POST: Control/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Deleted = 1;
                _context.Update(user);
                // _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
    }

   
}
