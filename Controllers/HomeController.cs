using System;
using System.Runtime;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using DocShare.Models;

namespace DocShare.Controllers
{
    public class HomeController : Controller
    {
        //MyContext object for pointing to the database and connecting to the tables
        private MyContext dbContext;
        private readonly IWebHostEnvironment myWebHostEnvirontment;
        public HomeController(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            dbContext = context;
            myWebHostEnvirontment = webHostEnvironment;
        }

        //Check if the email already exists in the database.
        private bool EmailExists(string Email)
        {
            User user = dbContext.Users.Where(c => c.Email == Email).FirstOrDefault();

            if(user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Login form.
        public IActionResult Index()
        {
            ViewBag.LoginError = HttpContext.Session.GetString("LoginError");
            HttpContext.Session.SetString("LoginError", "");
            return View();
        }

        //Confirm password matches saved hash and login user.
        [HttpPost("SubmitLogin")]
        public IActionResult SubmitLogin(User user)
        {
            string LoginErrorMessage = "Incorrect username or password.";
            User dbUser = dbContext.Users.Where(c => c.Email == user.Email).FirstOrDefault();
            PasswordHasher<User> Hasher = new PasswordHasher<User>();

            if(dbUser != null)
            {
                if(Hasher.VerifyHashedPassword(user, dbUser.Password, user.Password) != 0)
                {
                    HttpContext.Session.SetInt32("UserID", dbUser.UserID);        
                    HttpContext.Session.SetInt32("CompanyID", dbUser.CompanyID);        
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    HttpContext.Session.SetString("LoginError", LoginErrorMessage);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                HttpContext.Session.SetString("LoginError", LoginErrorMessage);
                return RedirectToAction("Index");
            }
        }

        //Send to the Registration Form and dispay any errors that might exist.
        [HttpGet("Register/{ActivationCode}")]
        public IActionResult Register(string ActivationCode)
        {
            User user = dbContext.Users.Where(c => c.ActivationCode == ActivationCode).FirstOrDefault();
            if(user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                user.CompanyTypes = dbContext.CompanyTypes.ToList();
                ViewBag.RegisterError = HttpContext.Session.GetString("RegisterError");
                HttpContext.Session.SetString("RegisterError", "");
                return View(user);
            }
        }

        //Register the user and save information in the database.
        [HttpPost("SubmitRegister")]
        public IActionResult SubmitRegister(User user)
        {
            user.AdminLevelID = 1;
            user.SetNewUser();
            string RegisterErrorMessage = "There was a problem with your registration, if the problem persists please contact administration.";
            
            User dbUser = dbContext.Users.Where(c => c.ActivationCode == user.ActivationCode)
                                .Include(c => c.Company)
                                .FirstOrDefault();

            if(user.Email != dbUser.Email)
            {
                User ExistingEmail = dbContext.Users.Where(c => c.Email == user.Email).FirstOrDefault();
                if(ExistingEmail != null)
                {
                    HttpContext.Session.SetString("LoginError", "An Account with that email already exists, please log in.");
                    return RedirectToAction("Index");
                }
                dbUser.Email = user.Email;
            }

            // Make sure there are no errors, hash password, and save user and company to DB.
            if(user.RegistrationSuccess())
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.PhoneNumber = user.PhoneNumber;
                dbUser.CreatedAt = DateTime.Now;
                dbUser.UpdatedAt = DateTime.Now;
                dbUser.Company.CreatedAt = DateTime.Now;
                dbUser.Company.UpdatedAt = DateTime.Now;
                dbUser.Company.PhoneNumber = user.Company.PhoneNumber;
                dbUser.Company.StreetAddress1 = user.Company.StreetAddress1;
                dbUser.Company.StreetAddress2 = user.Company.StreetAddress2;
                dbUser.Company.City = user.Company.City;
                dbUser.Company.State = user.Company.State;
                dbUser.Company.Zip = user.Company.Zip;
                dbUser.Company.CompanyTypeID = user.Company.CompanyTypeID;
                dbUser.Company.CompanyName = user.Company.CompanyName;
                dbUser.ActivationCode = null;
                
                PasswordHasher<string> Hasher = new PasswordHasher<string>();
                dbUser.Password = Hasher.HashPassword(user.Password, user.Password);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("UserID", dbUser.UserID);        
                HttpContext.Session.SetInt32("CompanyID", dbUser.CompanyID);  

                return RedirectToAction("Dashboard");
            }
            else
            {
                HttpContext.Session.SetString("RegisterError", RegisterErrorMessage);
                return RedirectToAction("Register");
            }
        }


        //Get user from DB and return view to dashboard
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");

            if(UserID == null)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                User dbUser = dbContext.Users.Where(c => c.UserID == UserID)
                .Include(c => c.AdminLevel)
                .Include(c => c.Company)
                .ThenInclude(c => c.CompanyType)
                .Include(c => c.Company)
                .ThenInclude(c => c.PatientCases)
                .ThenInclude(c => c.UploadFiles)
                .Include(c => c.Company)
                .ThenInclude(c => c.PatientCases)
                .ThenInclude(c => c.CompanyCases)
                .Include(c => c.Company)
                .ThenInclude(c => c.PatientCases)
                .ThenInclude(c => c.CaseLogs)
                .ThenInclude(c => c.User)
                .ThenInclude(c => c.Company)
                .Include(c => c.Company)
                .ThenInclude(c => c.PatientCases)
                .ThenInclude(c => c.CaseLogs)
                .ThenInclude(c => c.UploadFile)
                .Include(c => c.Company)
                .ThenInclude(c => c.PatientCases)
                .ThenInclude(c => c.CaseNotes)
                .ThenInclude(c => c.User)
                .ThenInclude(c => c.Company)
                .Include(c => c.Company)
                .ThenInclude(c => c.Companies)
                .ThenInclude(c => c.CompanyFriend)
                .Include(c => c.Company)
                .ThenInclude(c => c.Companies)
                .ThenInclude(c => c.Company)
                .Include(c => c.Company)
                .ThenInclude(c => c.FriendCompanies)
                .ThenInclude(c => c.Company)
                .Include(c => c.Company)
                .ThenInclude(c => c.FriendCompanies)
                .ThenInclude(c => c.CompanyFriend)
                .Include(c => c.Company)
                .ThenInclude(c => c.CompanyCases)
                .ThenInclude(c => c.PatientCase)
                .ThenInclude(c => c.CaseLogs)
                .ThenInclude(c => c.User)
                .ThenInclude(c => c.Company)
                .Include(c => c.Company)
                .ThenInclude(c => c.CompanyCases)
                .ThenInclude(c => c.PatientCase)
                .ThenInclude(c => c.UploadFiles)
                .Include(c => c.Company)
                .ThenInclude(c => c.CompanyCases)
                .ThenInclude(c => c.PatientCase)
                .ThenInclude(c => c.CaseNotes)
                .ThenInclude(c => c.User)
                .FirstOrDefault();

                dbUser.Company.SetLabPatientCases();
                dbUser.RemoveLoops();
                dbUser.Company.SetCompanyFriends();

                return View(dbUser);    
            }
        }

        [HttpPost]
        public async Task<IActionResult> CaseZipFilesUpload(int caseID = 0, List<int> caseIDs = null)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(UserID == null || CompanyID == null)
            {
                string failmessage = "Not logged in!";
                return Json(new { Message = failmessage });
            }
            else
            {
                Company dbCompany = dbContext.Companies.Where(c => c.CompanyID == CompanyID)
                                        .Include(c => c.CompanyCases)
                                        .ThenInclude(c => c.PatientCase)
                                        .FirstOrDefault();
                
                List<PatientCase> dbPatientCases = new List<PatientCase>();

                for(int i = 0; i < dbCompany.CompanyCases.Count(); i++)
                {
                    dbPatientCases.Add(dbCompany.CompanyCases[i].PatientCase);
                }
                dbPatientCases = dbPatientCases.OrderByDescending(c => c.CreatedAt).ToList();

                var uploadedFiles = Request.Form.Files;

                List<UploadFile> UFs = new List<UploadFile>();
                List<CaseLog> Logs = new List<CaseLog>();
                for(int i = 0; i < uploadedFiles.Count(); i++)
                {
                    DateTime timeNow = DateTime.Now;
                    string timeNowString = timeNow.Year.ToString() + "-"
                        + timeNow.Month.ToString() + "-"
                        + timeNow.Day.ToString() + "-"
                        + timeNow.Hour.ToString() + "-"
                        + timeNow.Minute.ToString() + "-"
                        + timeNow.Second.ToString() + "-"
                        + timeNow.Millisecond.ToString();
                    
                    string folder = "";
                    UploadFile UF = new UploadFile()
                    {
                        UploadFileName = uploadedFiles[i].FileName
                    };
                    bool ExpectedFile = false;
                    if(uploadedFiles[i].ContentType == "application/x-zip-compressed")
                    {
                        folder = "zips/";
                        UF.FileTypeID = 2;
                        ExpectedFile = true;
                    }

                    if(ExpectedFile)
                    {
                        string name = UF.UploadFileName.Substring(0, UF.UploadFileName.Length - 4);
                        PatientCase PC = dbPatientCases.Where(c => c.CaseName == name).FirstOrDefault();
                        if(PC != null)
                        {
                            folder += timeNowString + "_" + uploadedFiles[i].FileName;
                            folder = Regex.Replace(folder, " ", string.Empty);
                            string serverFolder = Path.Combine(myWebHostEnvirontment.WebRootPath, folder);
                            FileStream Fs = new FileStream(serverFolder, FileMode.Create);
                            await uploadedFiles[i].CopyToAsync(Fs);
                            await Fs.DisposeAsync();
                            UF.UploadFilePath = "/" + folder;
                            UF.PatientCaseID = PC.PatientCaseID;
                            PC.LogDesignerUploadFile(UF, UserID);
                            PC.CaseLogs[0].UploadFile = UF;
                            PC.CasePhaseID = 4;
                            Logs.Add(PC.CaseLogs[0]);
                            UFs.Add(UF);
                        }
                    }
                }               
                
                dbContext.AddRange(UFs);
                dbContext.SaveChanges();

                List<CaseLog> message = Logs;
                return Json(new { Message = message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ZipFilesUpload(int caseID = 0, List<int> caseIDs = null)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(UserID == null || CompanyID == null)
            {
                string failmessage = "Not logged in!";
                return Json(new { Message = failmessage });
            }
            else
            {
                var uploadedFiles = Request.Form.Files;

                List<UploadFile> UFs = new List<UploadFile>();
                for(int i = 0; i < uploadedFiles.Count(); i++)
                {
                    DateTime timeNow = DateTime.Now;
                    string timeNowString = timeNow.Year.ToString() + "-"
                        + timeNow.Month.ToString() + "-"
                        + timeNow.Day.ToString() + "-"
                        + timeNow.Hour.ToString() + "-"
                        + timeNow.Minute.ToString() + "-"
                        + timeNow.Second.ToString() + "-"
                        + timeNow.Millisecond.ToString();
                    
                    string folder = "";
                    UploadFile UF = new UploadFile()
                    {
                        UploadFileName = uploadedFiles[i].FileName
                    };
                    bool ExpectedFile = false;
                    if(uploadedFiles[i].ContentType == "application/x-zip-compressed")
                    {
                        folder = "zips/";
                        UF.FileTypeID = 2;
                        ExpectedFile = true;
                    }
                    else if(uploadedFiles[i].ContentType.Substring(0, 6) == "image/")
                    {
                        folder = "images/";
                        UF.FileTypeID = 1;
                        UF.PatientCaseID = caseID;
                        ExpectedFile = true;                        
                    }

                    if(ExpectedFile)
                    {
                        folder += timeNowString + "_" + uploadedFiles[i].FileName;
                        folder = Regex.Replace(folder, " ", string.Empty);
                        string serverFolder = Path.Combine(myWebHostEnvirontment.WebRootPath, folder);
                        FileStream Fs = new FileStream(serverFolder, FileMode.Create);
                        await uploadedFiles[i].CopyToAsync(Fs);
                        await Fs.DisposeAsync();                        
                        UF.UploadFilePath = "/" + folder;
                        UFs.Add(UF);
                    }
                }
                dbContext.AddRange(UFs);
                dbContext.SaveChanges();

                List<UploadFile> message = UFs;
                return Json(new { Message = message });
            }
        }

        [HttpPost]
        public IActionResult SubmitCaseNoteRead(int caseID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });                
            }

            PatientCase dbPatientCase = dbContext.PatientCases.Where(c => c.PatientCaseID == caseID)
                                            .Include(c => c.CaseNotes)
                                            .FirstOrDefault();

            dbPatientCase.ReadNotes((int)CompanyID);
            dbContext.SaveChanges();

            string Message = "Success!";
            return Json(new { Message = Message });                
        }

        [HttpPost]
        public IActionResult SubmitNewCaseMessage(CaseNote newNote)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });                
            }

            newNote.CompanyID = (int)CompanyID;
            newNote.UserID = (int)UserID;
            newNote.CreatedAt = DateTime.Now;
            newNote.User = dbContext.Users.Where(c => c.UserID == UserID).FirstOrDefault();
            newNote.SenderName = $"{newNote.User.FirstName} {newNote.User.LastName}";
            newNote.NoteRead = false;

            dbContext.Add(newNote);
            dbContext.SaveChanges();

            CaseNote message = newNote;
            return Json(new { Message = message });
        }

        [HttpPost]
        public IActionResult SubmitHoldCase(int PatientCaseID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || PatientCaseID == 0)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });                
            }

            PatientCase dbCase = dbContext.PatientCases.Where(c => c.PatientCaseID == PatientCaseID).FirstOrDefault();
            if(dbCase.Hold)
            {
                dbCase.Hold = false;
                dbCase.LogCaseRemoveHold(UserID);
            }
            else
            {
                dbCase.Hold = true;
                dbCase.LogCaseHold(UserID);
            }

            dbContext.SaveChanges();

            string message = "Hold Success";
            return Json(new { Message = message });
        }

        [HttpPost]
        public IActionResult SubmitDeleteCase(int PatientCaseID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || PatientCaseID == 0)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });                
            }

            PatientCase dbCase = dbContext.PatientCases
            .Where(c => c.PatientCaseID == PatientCaseID)
            .Include(c => c.CaseNotes)
            .Include(c => c.UploadFiles)
            .Include(c => c.CaseLogs)
            .Include(c => c.CompanyCases)
            .FirstOrDefault();

            if(dbCase.CompanyID == CompanyID)
            {
                dbContext.Remove(dbCase);
                dbContext.SaveChanges();

                string message = "Case Successfully Deleted";
                return Json(new { Message = message });
            }
            else
            {
                string message = "You are not authorized to delete this case.";
                return Json(new { Message = message });
            }
        }

        [HttpPost]
        public IActionResult SubmitNewSupplier(string email)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || email == null)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });
            }

            User dbUser = dbContext.Users.Where(c => c.Email == email)
                                    .Include(c => c.Company)
                                    .FirstOrDefault();

            if(dbUser == null)
            {
                User newUser = new User()
                {
                    Email = email,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    AdminLevelID = 1,
                    Company = new Company()
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        FriendCompanies = new List<FriendCompany>()
                        {
                            new FriendCompany()
                            {
                                CompanyID = (int)CompanyID            
                            }
                        }
                    }
                };
                // FriendCompany FC = new FriendCompany()
                // {
                //     CompanyID = (int)CompanyID,
                //     FriendCompanyID = (int)CompanyID,
                //     CompanyFriend = newUser.Company
                // };

                // newUser.Company.FriendCompanies.Add(FC);

                newUser.GenerateActivationCode();
                newUser.SendAccountActivationEmail();

                dbContext.Add(newUser);
                dbContext.SaveChanges();

                string message = "Thank you for adding another supplier. Once they register their account they will be added as a supplier for you.";
                return Json(new { Message = message });
            }
            else{
                FriendCompany FC = new FriendCompany()
                {
                    CompanyID = (int)CompanyID,
                    FriendCompanyID = dbUser.CompanyID,
                    CompanyFriend = dbUser.Company
                };

                dbContext.Add(FC);
                dbContext.SaveChanges();

                return Json(new { Message = FC });
            }
        }

        [HttpPost]
        public IActionResult SubmitUploadCase(int caseID)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || caseID == 0)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });
            }

            PatientCase dbCase = dbContext.PatientCases.Where(c => c.PatientCaseID == caseID && c.CompanyID == CompanyID)
                                        .Include(c => c.CompanyCases)
                                        .Include(c => c.CaseNotes)
                                        .ThenInclude(c => c.User)
                                        .Include(c => c.CaseLogs)
                                        .ThenInclude(c => c.UploadFile)
                                        .Include(c => c.UploadFiles)
                                        .FirstOrDefault();

            if(dbCase == null)
            {
                string strMessage = "You are not authorized to edit this case.";
                return Json(new { Message = strMessage });
            }

            if(dbCase.CompanyCases == null)
            {
                string strMessage = "Company cases not found.";
                return Json(new { Message = strMessage });
            }

            for(int i = 0; i < dbCase.CompanyCases.Count(); i++)
            {
                dbCase.CompanyCases[i].CaseSubmitted = true;
            }

            dbCase.CasePhaseID = 2;

            dbContext.SaveChanges();

            return Json(new { Message = dbCase.PatientCaseID });
        }

        [HttpGet]
        public async Task<IActionResult> SubmitDownloadFile(string filePath)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || filePath == "" || filePath == null)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });
            }

            UploadFile UF = dbContext.UploadFiles.Where(c => c.UploadFilePath == filePath).FirstOrDefault();
            PatientCase patientCase = dbContext.PatientCases.Where(c => c.PatientCaseID == UF.PatientCaseID).FirstOrDefault();
            if(CompanyID != patientCase.CompanyID)
            {
                UF.Downloaded = true;
                patientCase.CasePhaseID = 3;
                patientCase.LogDesignerDownloadFile(UF, CompanyID);
                dbContext.SaveChanges();
            }

            filePath = filePath.Substring(1);
            Console.WriteLine(Directory.GetCurrentDirectory());
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);
            Console.WriteLine(path);
            var memory = new MemoryStream();
            using(var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
                await stream.DisposeAsync();
            }
            memory.Position = 0;
            var ContentType = "application/x-zip-compressed";
            var fileName = Path.GetFileName(path);

            return File(memory, ContentType, fileName);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SubmitNewDBCases(List<PatientCase> Cases)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            int? CompanyID = HttpContext.Session.GetInt32("CompanyID");
            
            if(CompanyID == null || UserID == null || Cases == null)
            {
                string strMessage = "Not logged in!";
                return Json(new { Message = strMessage });
            }

            List<int> uploadFileIDs = Cases.Select(c => c.CasePhaseID).ToList();
            List<UploadFile> UFs = dbContext.UploadFiles.Where(c => uploadFileIDs.Contains(c.UploadFileID)).ToList();

            for(int i = 0; i < Cases.Count(); i++)
            {
                Cases[i].CompanyID = (int)CompanyID;
                Cases[i].Hold = false;
                Cases[i].CasePhaseID = 1;
                Cases[i].CreatedAt = DateTime.Now;
                Cases[i].UpdatedAt = DateTime.Now;
                Cases[i].PatientCaseID = 0;
                Cases[i].UploadFiles = new List<UploadFile>();
                Cases[i].UploadFiles.Add(UFs[i]);
                Cases[i].LogNewCaseUpload(UFs[i], UserID);
                CompanyCase newCompanyCase = new CompanyCase()
                {
                    CompanyID = Cases[i].LabID,
                    CaseSubmitted = false
                };
                if(Cases[i].CompanyCases == null)
                {
                    Cases[i].CompanyCases = new List<CompanyCase>()
                    {
                        newCompanyCase
                    };
                }
                else
                {
                    Cases[i].CompanyCases.Add(newCompanyCase);
                }
            }

            dbContext.AddRange(Cases);
            dbContext.SaveChanges();

            string message = "Success!";
            return Json(new { Message = message });
        }
    }
}
