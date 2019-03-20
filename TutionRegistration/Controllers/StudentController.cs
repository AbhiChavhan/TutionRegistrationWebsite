using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TutionRegistration.Models;
using TutionRegistration.ViewModels;

namespace TutionRegistration.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext _context;


        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            var student = _context.Students.ToList();
            return View(student);
        }

        public ActionResult NewStudentRegistration()
        {
            var batches = _context.Batches.ToList();

            var viewModel = new StudentRegisterViewModel
            {
                Batches = batches
            };
            return View("NewStudentRegistration", viewModel);
            //return View();
        }

        [HttpPost]
        public ActionResult Create(Students students)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("NewStudentRegistration");
            }
            _context.Students.Add(students);
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        //Approve student
        public ActionResult EditStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            student.Approved = true;
            _context.SaveChanges();

            MailToApproveStudent(id);

            return RedirectToAction("Index");
        }

        public ViewResult MailToApproveStudent(int id)
        {
            Students students = _context.Students.Find(id);
            var email = ConfigurationManager.AppSettings.Get("email");
            var password = ConfigurationManager.AppSettings.Get("password");

            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(students.Email);
                //mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress("abhishek.chavhan@sumasoft.net");
                mail.Subject = "About your registration in Marvellous Infosystems";
                string Body = GenerateIdPass(id);
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(email, password), // Enter seders User name and password  
                    EnableSsl = true
                };
                smtp.Send(mail);
                return View("Index");
            }
            else
            {
                return View(HttpNotFound());
            }
        }

        //hya fun madhun email chi body return hoil
        public String GenerateIdPass(int id)
        {
            var studData = _context.Students.Find(id);
            string Finalkey = GenerateKey(id);  //encrypted key to specific user
            studData.ExamKey = Finalkey; //key database madhe store keli
            _context.SaveChanges();
            string EmailBody = $"Hello {studData.Name}, <br/><br/> " +
                                $"Your registration process is complete. Welcome to Marvellous Infosystem Family." +
                                $"Please note down below ID and Secret Key for online examination.<br/><br/>" +
                                $"Your ID:   {studData.Email}<br/>" +
                                $"Your Key:   {Finalkey}<br/><br/>" +
                                $"Thanks & Regards<br/>" +
                                $"Marvellous Admin";

            return EmailBody;

        }

        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //hya fun madhun key return hoil
        public String GenerateKey(int id)
        {
            char[] arr = new char[8];
            var studInfo = _context.Students.Find(id);
            string email = studInfo.Email;
            char[] EmailInCharArr = email.ToCharArray();

            //haa for loop ne arr madhe first 8 characters copy kele
            for(int i = 0; i < 8; i++)
            {
                arr[i] = EmailInCharArr[i];
            }

            var randomString = RandomString(arr.Length);

            //string finalKey = Convert.ToString(arr);
            return randomString;
        }

        public ActionResult DisApprove(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            student.Approved = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int id)
        {
            var deleteStudent = _context.Students.Find(id);
            Students students = deleteStudent;
            if(deleteStudent == null)
            {
                return HttpNotFound();
            }

            _context.Students.Remove(students);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}