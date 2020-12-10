using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ForumWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BookStore store;
        private int UserId => int.Parse(User.Claims.Single(
            c => c.Type == ClaimTypes.NameIdentifier).Value);

        public OrdersController(BookStore store)
        {
            this.store = store;
        }

        [HttpGet]
        [Authorize (Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            if (!store.Orders.ContainsKey(UserId))
                return Ok(Enumerable.Empty<Book>());

            var orderedBooksIds = store.Orders.Single(o => o.Key == UserId).Value;
            var orderedBooks = store.Books.Where(b => orderedBooksIds.Contains(b.Id));

            return Ok(orderedBooks);
        }
    }
}