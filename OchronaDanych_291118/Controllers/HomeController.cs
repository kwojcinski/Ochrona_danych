using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OchronaDanych_291118.Models;

namespace OchronaDanych_291118.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFDbContext _context;

        public HomeController(ILogger<HomeController> logger, EFDbContext context)
        {
            _logger = logger; 
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!IsValidEmail(model.Email))
            {
                ModelState.AddModelError("Email", "Błędny adres email.");
                return View(model);
            }
            User userLogin = _context.Users.FirstOrDefault(x => x.Login == model.Login);
            if (userLogin != null)
            {
                ModelState.AddModelError("Login", "Istnieje użytkownik o takim loginie.");
                return View(model);
            }
            User userEmail = _context.Users.FirstOrDefault(x => x.Email == model.Email);
            if (userEmail != null)
            {
                ModelState.AddModelError("Email", "Istnieje użytkownik o takim adresie email.");
                return View(model);
            }
            if (!model.Password.Any(char.IsDigit))
            {
                ModelState.AddModelError("Password", "Hasło musi zawierać liczbę.");
                return View(model);
            }
            if (!model.Password.Any(char.IsUpper))
            {
                ModelState.AddModelError("Password", "Brak wielkich liter.");
                return View(model);
            }
            if (!model.Password.Any(char.IsLower))
            {
                ModelState.AddModelError("Password", "Brak małych liter.");
                return View(model);
            }
            if (!model.Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ModelState.AddModelError("Password", "Brak specjalnych znaków.");
                return View(model);
            }
            var entropy = model.Password.Length * Math.Log2(94);
            if (entropy < 25)
            {
                ModelState.AddModelError("Password", "Twoje hasło jest zdecydowanie za słabe..");
                return View(model);
            }
            if (entropy < 50)
            {
                ModelState.AddModelError("Password", "Twoje hasło jest za słabe.");
                return View(model);
            }
            if (!model.Password.Equals(model.RepeatPassword))
            {
                ModelState.AddModelError("RepeatPassword", "Hasła muszą się zgadzać.");
                return View(model);
            }
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            User newUser = new User
            {
                Email = model.Email,
                Login = model.Login,
                Password = savedPasswordHash,
                Notes = new List<Note>(),
                LogTries = 0,
                IsLocked = false
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Email),
                        new Claim(ClaimTypes.Name, model.Login),
                        new Claim(ClaimTypes.Email, model.Email)
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            model.Attempts = 1;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = _context.Users.FirstOrDefault(x => x.Login == model.Login);
            if(user == null)
            {
                ModelState.AddModelError("Login", "Użytkownik o takim loginie nie istnieje.");
                return View(model);
            }
            else if (user.LogTries >= 5)
            {
                await _context.SaveChangesAsync();
                model.Attempts = 0;
                ModelState.AddModelError("Login", "Twoje konto zostało zablokowane, skontaktuj się z administratorem w celu odzyskania konta.");
                return View(model);
            }
            Thread.Sleep(2000);
            string savedPasswordHash = user.Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(model.Password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    user.LogTries += 1;
                    model.Attempts = user.LogTries + 1;
                    if(user.LogTries == 5)
                    {
                        model.Attempts = 0;
                        user.IsLocked = true;
                        ModelState.AddModelError("Login", "Twoje konto zostało zablokowane, skontaktuj się z administratorem w celu odzyskania konta.");
                        await _context.SaveChangesAsync();
                        return View(model);
                    }
                    await _context.SaveChangesAsync();
                    ModelState.AddModelError("Password", "Hasło nieprawidłowe.");
                    return View(model);
                }
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Email),
                        new Claim(ClaimTypes.Name, user.Login),
                        new Claim(ClaimTypes.Email, user.Email)
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            user.LogTries = 0;
            user.IsLocked = false;
            await _context.SaveChangesAsync();
            await HttpContext.SignInAsync(principal);
            HttpContext.Session.SetString("Attempts", "1");
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Profile()
        {
            List<Note> list = _context.Users.Include(x => x.Notes).FirstOrDefault(x => x.Login == User.Identity.Name).Notes;
            return View(list);
        }
        [Authorize]
        public IActionResult AddNote()
        {
            NoteViewModel model = new NoteViewModel();
            model.IsForEveryone = true;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNote(NoteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Note note = new Note();
            note.AcceptedUsersEmails = new List<Email>();
            if (!model.IsForEveryone)
            {
                string[] userEmailsSplited;
                if (!String.IsNullOrEmpty(model.Emails))
                {
                    userEmailsSplited = model.Emails.Replace(" ", "").Split(";");
                    foreach (string email in userEmailsSplited)
                    {
                        if (!(new EmailAddressAttribute().IsValid(email)))
                        {
                            ModelState.AddModelError("Emails", "Jeden z emaili ma nieprawidłowy format.");
                            return View(model);
                        }
                        Email e = new Email
                        {
                            EmailAddress = email
                        };
                        note.AcceptedUsersEmails.Add(e);
                    }
                }
                Email em = new Email
                {
                    EmailAddress = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value
                };
                note.AcceptedUsersEmails.Add(em);
            }
            note.Title = model.Title;
            note.Description = model.Description;
            note.IsForEveryone = model.IsForEveryone;
            User user = _context.Users.Include(x => x.Notes).ThenInclude(n => n.AcceptedUsersEmails).FirstOrDefault(x => x.Login == User.Identity.Name);
            user.Notes.Add(note);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }
        [Authorize]
        public IActionResult Note(int id)
        {
            Note note = _context.Notes.Include(x => x.AcceptedUsersEmails).FirstOrDefault(x => x.Id == id);
            if (note.IsForEveryone)
            {
                return View(note);
            }
            else
            {
                string userEmail = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value;
                foreach(Email email in note.AcceptedUsersEmails)
                {
                    if (userEmail.Equals(email.EmailAddress))
                        return View(note);
                }
                return RedirectToAction("Denied");
            }
        }
        [Authorize]
        public IActionResult EditNote(int id)
        {
            Note note = _context.Notes.Include(x => x.Author).Include(x => x.AcceptedUsersEmails).FirstOrDefault(x => x.Id == id);
            if (!note.Author.Login.Equals(User.Identity.Name))
            {
                return RedirectToAction("Denied");
            }
            else
            {
                NoteViewModel model = new NoteViewModel();
                model.Id = id;
                model.Title = note.Title;
                model.Description = note.Description;
                model.IsForEveryone = note.IsForEveryone;
                string emails = "";
                foreach(Email email in note.AcceptedUsersEmails)
                {
                    emails += email.EmailAddress + ";";
                }
                model.Emails = emails;
                return View(model);
            }
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditNote(NoteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Note note = _context.Notes.Include(x => x.Author).Include(x => x.AcceptedUsersEmails).FirstOrDefault(x => x.Id == model.Id);
            if (!note.Author.Login.Equals(User.Identity.Name))
            {
                return RedirectToAction("Denied");
            }
            note.AcceptedUsersEmails = new List<Email>();
            if (!model.IsForEveryone)
            {
                string[] userEmailsSplited;
                if (!String.IsNullOrEmpty(model.Emails))
                {
                    userEmailsSplited = model.Emails.Replace(" ", "").Split(";");
                    foreach (string email in userEmailsSplited)
                    {
                        if (!(new EmailAddressAttribute().IsValid(email)))
                        {
                            ModelState.AddModelError("Emails", "Jeden z emaili ma nieprawidłowy format.");
                            return View(model);
                        }
                        Email e = new Email
                        {
                            EmailAddress = email
                        };
                        note.AcceptedUsersEmails.Add(e);
                    }
                }
                Email em = new Email
                {
                    EmailAddress = User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value
                };
                note.AcceptedUsersEmails.Add(em);
            }
            note.Title = model.Title;
            note.Description = model.Description;
            note.IsForEveryone = model.IsForEveryone;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> DeleteNote(int Id)
        {
            Note note = _context.Notes.Include(x => x.Author).FirstOrDefault(x => x.Id == Id);
            if (!note.Author.Login.Equals(User.Identity.Name))
            {
                return RedirectToAction("Denied");
            }
            User user = _context.Users.Include(x => x.Notes).FirstOrDefault(x => x.Login == User.Identity.Name);
            user.Notes.RemoveAll(x => x.Id == Id);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }
        [Authorize]
        public IActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = _context.Users.Include(x => x.Notes).FirstOrDefault(x => x.Login == User.Identity.Name);
            string savedPasswordHash = user.Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(model.OldPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    ModelState.AddModelError("OldPassword", "Hasło nieprawidłowe.");
                    return View(model);
                }
            if (model.NewPassword.Equals(model.OldPassword))
            {
                ModelState.AddModelError("NewPassword", "Hasło nie może być takie samo jak poprzednie.");
                return View(model);
            }
            if (!model.NewPassword.Any(char.IsDigit))
            {
                ModelState.AddModelError("NewPassword", "Hasło musi zawierać liczbę.");
                return View(model);
            }
            if (!model.NewPassword.Any(char.IsUpper))
            {
                ModelState.AddModelError("NewPassword", "Brak wielkich liter.");
                return View(model);
            }
            if (!model.NewPassword.Any(char.IsLower))
            {
                ModelState.AddModelError("NewPassword", "Brak małych liter.");
                return View(model);
            }
            if (!model.NewPassword.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                ModelState.AddModelError("NewPassword", "Brak specjalnych znaków.");
                return View(model);
            }
            var entropy = model.NewPassword.Length * Math.Log2(94);
            if (entropy < 25)
            {
                ModelState.AddModelError("NewPassword", "Twoje hasło jest zdecydowanie za słabe..");
                return View(model);
            }
            if (entropy < 50)
            {
                ModelState.AddModelError("NewPassword", "Twoje hasło jest zdecydowanie za słabe.");
                return View(model);
            }
            if (!model.NewPassword.Equals(model.NewRepeatPassword))
            {
                ModelState.AddModelError("NewRepeatPassword", "Hasła muszą się zgadzać.");
                return View(model);
            }
            byte[] saltN;
            new RNGCryptoServiceProvider().GetBytes(saltN = new byte[16]);
            var pbkdf2N = new Rfc2898DeriveBytes(model.NewPassword, saltN, 10000);
            byte[] hashN = pbkdf2N.GetBytes(20);
            byte[] hashBytesN = new byte[36];
            Array.Copy(saltN, 0, hashBytesN, 0, 16);
            Array.Copy(hashN, 0, hashBytesN, 16, 20);
            string savedPasswordHashN = Convert.ToBase64String(hashBytesN);
            user.Password = savedPasswordHashN;
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", new { c = true });
        }
        public bool IsValidEmail(string source)
        {
            if (source == null)
                return false;
            else
                return new EmailAddressAttribute().IsValid(source);
        }
        [Authorize]
        public IActionResult Notes()
        {
            List<Note> notes = _context.Notes.Where(x => x.IsForEveryone).ToList();
            return View(notes);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Denied()
        {
            return View();
        }
    }
}
