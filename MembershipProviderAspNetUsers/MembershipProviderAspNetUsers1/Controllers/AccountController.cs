using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MembershipProviderAspNetUsers.Models;
using System.Web.Security;

namespace MembershipProviderAspNetUsers.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        /*Even in KVK, Membership is used for login, create user and authentication,
          Membership can be configured by following the sites -
          https://www.c-sharpcorner.com/UploadFile/deepak.sharma00/how-to-configure-Asp-Net-membership-using-sqlmembershipprovi/
          http://mahedee.net/asp-net-membership-step-by-step/
          Open Visual Studio Command Prompt --> Type command : aspnet_regsql and press Enter --> This will launch ASP.NET SQL Server Setup Wizard and then changes in
          Web.Config:
          <membership defaultProvider="MyMembershipProvider" >
            <providers>
              <add name="MyMembershipProvider"
          type="System.Web.Security.SqlMembershipProvider"
          connectionStringName="ConString" />
             </providers>
            </membership>
            
            <connectionString>
            <add name="AspNetMembershipConn" connectionString="Data Source=ASPIRE2044;Initial Catalog=aspnetdb;Integrated Security = SSPI"/>    
            </connectionString>
             */


        /*https://forums.asp.net/t/1016718.aspx?Membership+CreateUser*/
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(Membership.ValidateUser(login.UserName,login.Password)) // Membership.ValidateUser to validate the user credentials
            {
                FormsAuthentication.SetAuthCookie(login.UserName, login.Rememberme); /*Creates a authentication ticket for the user name and sets it in cookies collection , this ticket
                supplies the forms-authentication information to the next request made by the browser.*/
               
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //[Bind(Exclude = "Confirm Password")]
        
        public ActionResult Register([Bind(Exclude = "ConfirmPassword")] Register user)
        {
            Membership.CreateUser(user.UserName,user.Password);
            Membership.GetUser()
            return View();
        }
    }
}