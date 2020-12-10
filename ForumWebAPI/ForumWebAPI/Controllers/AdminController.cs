using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ForumWebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class AdminController : ApiController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        [Route("complaint/{id:int}")]
        public IHttpActionResult GetComplaintById(int id)
        {
            var complaint = adminService.GetComplaintById(id);

            if (complaint != null)
            {
                return Ok(complaint);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("complaints")]
        public IHttpActionResult GetComplaints()
        {
            var complaint = adminService.GetAllComplaints();
            return Ok(complaint);
        }

        [HttpPut]
        [Route("accept")]
        public IHttpActionResult AcceptComplaint(int id)
        {
            adminService.AcceptComplaint(id);
            return Ok();
        }

        [HttpDelete]
        [Route("accept")]
        public IHttpActionResult DiscardComplaint(int id)
        {
            adminService.DiscardComplaint(id);
            return Ok();
        }
    }
}