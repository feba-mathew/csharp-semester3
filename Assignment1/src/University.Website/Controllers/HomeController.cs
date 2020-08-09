using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Business;
using University.Website.Models;



namespace University.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClassManager classManager;
        private readonly IUserManager userManager;
        private readonly IUserClassManager userClassManager;
        public HomeController(IClassManager classManager, IUserManager userManager, IUserClassManager userClassManager)
        {
            this.classManager = classManager;
            this.userManager = userManager;
            this.userClassManager = userClassManager;
        }

       
        public HomeController(IClassManager classManager)
        {
            this.classManager = classManager;
        }
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult ClassList()
        {
            var classes = classManager.Classes
                                            .Select(t => new University.Website.Models.ClassModel(t.Id, t.Name, t.Description, t.Price))
                                            .ToArray();
            var model = new ClassListModel { Classes = classes };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult EnrollInClass()
        {
            var classes = classManager.Classes.Select(t => new University.Website.Models.ClassModel(t.Id, t.Name, t.Description, t.Price))
                                              .ToList();

            List<SelectListItem> classList = new List<SelectListItem>();
            
            foreach(var classEntry in classes)
            {
                classList.Add(new SelectListItem { Text = classEntry.Name, Value = classEntry.Id.ToString() });
            }

            ViewBag.ClassList = new SelectList(classList, "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult EnrollInClass(EnrollInClassModel enrollInClassModel)
        {
            Models.UserModel userModel = (Models.UserModel)Session["User"];

            UserClassModel userClassModel = new UserClassModel();
            userClassModel.ClassId = enrollInClassModel.SelectedClassId;
            userClassModel.UserId = userModel.Id;

            userClassManager.EnrollInClass(userClassModel);

            return Redirect("~/Home/StudentClasses");
        }

        [HttpGet]
        public ActionResult StudentClasses()
        {
            Models.UserModel userModel = (Models.UserModel)Session["User"];

            if (userModel != null)
            {
                if (RouteData.Values.TryGetValue("id", out object classIdObject))
                {
                    int classId = Convert.ToInt32(classIdObject);

                    UserClassModel userClassModel = new UserClassModel();
                    userClassModel.ClassId = classId;
                    userClassModel.UserId = userModel.Id;

                    userClassManager.RemoveUserFromClass(userClassModel);
                }

                var classes = userClassManager.GetUserClasses(userModel.Id)
                                              .Select(t => new University.Website.Models.ClassModel(t.Id, t.Name, t.Description, t.Price))
                                              .ToArray();

                var model = new StudentClassesModel { Classes = classes };

                return View(model);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                userManager.Register(registerModel.Email, registerModel.Password);

                return Redirect("~/");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogInModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Login(loginModel.UserName, loginModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new University.Website.Models.UserModel
                    {
                        Id = user.Id,
                        Name = user.Name
                    };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(
                        loginModel.UserName, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(loginModel);
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("~/");
        }
    }
}