using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _Context;

        public BuggyController(StoreContext context)
        {
            _Context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var err= _Context.Products.Find(34);
            if(err==null)
            return NotFound(new ApiResponse(404));

          return Ok();
        }

         [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var err= _Context.Products.Find(34);
            var ret=err.ToString();

          return Ok();
        }

         [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
          return BadRequest(new ApiResponse(400));
        }

        
         [HttpGet("badRequest/{id}")]
        public ActionResult GotNoFoundRequest(int id)
        {
          return Ok();
        }
    }
}