using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebAPI.Controllers
{
   // [Authorize(Roles = "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase//ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //[HttpGet]
        //[Route("user/{id:int}")]
        //public IHttpActionResult GetUser(int id)
        //{
        //    var user = userService.GetById(id);

        //    if(user != null)
        //    {
        //        return Ok(user);
        //    }
        //    return NotFound();
        //}

        //-
        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers()
        {
            var user = userService.GetAll();
            return Ok(user);
        }

        //[HttpGet]
        //[Route("user/{id:int}/OwnTopics")]
        //public IHttpActionResult GetOwnTopics(int id)
        //{
        //    var topic = userService.GetOwnTopics(id);
        //    return Ok(topic);
        //}

        //[HttpGet]
        //[Route("user/{id:int}/SubscribedTopics")]
        //public IHttpActionResult GetSubscribedTopics(int id)
        //{
        //    var topic = userService.GetSubscribedTopics(id);
        //    return Ok(topic);
        //}

        //[HttpGet]
        //[Route("user/{id:int}/Complaints")]
        //public IHttpActionResult GetComplaints(int id)
        //{
        //    var complaint = userService.GetAllComplaints(id);
        //    return Ok(complaint);
        //}

        //[HttpGet]
        //[Route("user/{id:int}/Complaint/{id:int}")]
        //public IHttpActionResult GetComplaintById(int idUser, int idComp)
        //{
        //    var complaint = userService.GetComplaintById(idUser, idComp);
        //    return Ok(complaint);
        //}

        //[HttpPost]
        //[Route("create")]
        //public IHttpActionResult CreateUser(string email,
        //    string password)
        //{
        //    UserDTO user = new UserDTO
        //    {
        //        Email = email,
        //        Password = password,
        //        RegistrationDate = DateTime.Now,
        //        IsBlocked = false,
        //        RoleDTO = RoleDTO.User,
        //    };
        //    userService.AddUser(user);
        //    return Ok();
        //}
    }
}