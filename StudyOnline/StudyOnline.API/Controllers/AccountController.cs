using StudyOnline.Common;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudyOnline.API.Controllers
{
    public class AccountController : ApiController
    {
        //UserService userService = new UserService();
        //[HttpPost, ActionName("Login")]
        //public int Login(User model)
        //{
        //    var result = userService.Login(model.UserName, Encryptor.MD5Hash(model.Password));
        //    if (result == 1)
        //    {
        //        var user = userService.GetById(model.UserName);
        //        var userSession = new UserLogin();
        //        userSession.UserName = user.UserName;
        //        userSession.UserID = user.ID;
        //        Section.Add(Common.CommonConstants.User_Session, userSession); //Thêm vào Session
        //    }
        //    return user;
        //}
    }
}
