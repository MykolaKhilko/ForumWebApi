using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ForumWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TopicController : ApiController
    {
        private readonly ITopicService topicService;
        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public TopicController(ITopicService topicService,
            IMessageService messageService, IUserService userService)
        {
            this.topicService = topicService;
            this.messageService = messageService;
            this.userService = userService;
    }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTopics()
        {
            var topic = topicService.GetAll();
            return Ok(topic);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetTopicById(int id)
        {
            var topic = topicService.GetById(id);

            if (topic != null)
            {
                return Ok(topic);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}/complaints")]
        public IHttpActionResult GetComplaints(int id)
        {
            var complaint = topicService.GetAllComplaints(id);
            return Ok(complaint);
        }

        [HttpGet]
        [Route("{id:int}/complaint/{id:int}")]
        public IHttpActionResult GetComplaintById(int idTopic, int idComp)
        {
            var complaint = topicService.GetComplaintById(idTopic, idComp);

            if (complaint != null)
            {
                return Ok(complaint);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}/messages")]
        public IHttpActionResult GetMessages(int id)
        {
            var message = messageService.GetAllByTopic(id);
            return Ok(message);
        }

        [HttpGet]
        [Route("{id:int}/message/{id:int}")]
        public IHttpActionResult GetMessageById(int idTopic, int idMess)
        {
            var message = messageService.GetByIdByTopic(idTopic, idMess);

            if (message != null)
            {
                return Ok(message);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}/message/{id:int}/complaints")]
        public IHttpActionResult GetMessageComplaints(int id, int idMess)
        {
            var complaint = messageService.GetAllComplaints(id, idMess);
            return Ok(complaint);
        }

        [HttpGet]
        [Route("{id:int}/message/{id:int}/complaint/{id:int}")]
        public IHttpActionResult GetMessageComplaintById(int idTopic, int idMess, int idComp)
        {
            var complaint = messageService.GetComplaintById(idTopic, idMess, idComp);

            if (complaint != null)
            {
                return Ok(complaint);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreateTopic(int idUser, string name, string desc)
        {
            TopicDTO topic = new TopicDTO
            {
                Name = name,
                Description = desc,
                Creator = userService.GetById(idUser),
                OpenDate = DateTime.Now,
                Messages = new List<MessageDTO>(),
                Complaints = new List<ComplaintDTO>(),
                Subscribers = new List<UserDTO>(),
                IsClosed = false,
                IsDeleted = false
            };
            topicService.Add(topic);
            return Ok(topic);
        }

        [HttpPost]
        [Route("{id:int}/message/create")]
        public IHttpActionResult CreateMessageInTopic(int idUser, int idTopic, 
            string text)
        {
            MessageDTO message = new MessageDTO
            {
                Author = userService.GetById(idUser),
                Text = text,
                PostDate = DateTime.Now,
                IsDeleted = false,
                Complaints = new List<ComplaintDTO>()
            };
            messageService.AddToTopic(idTopic, message);
            return Ok(message);
        }

        [HttpPost]
        [Route("{id:int}/complaint/create")]
        public IHttpActionResult CreateComplaintToTopic(int idTopic, string desc)
        {
            topicService.AddComplaint(idTopic, desc);
            return Ok();
        }

        [HttpPost]
        [Route("{id:int}/message/{id:int}/complaint/create")]
        public IHttpActionResult CreateComplaintToTopic(int idTopic, int idMess, string desc)
        {
            messageService.AddComplaint(idTopic, idMess, desc);
            return Ok();
        }
    }
}