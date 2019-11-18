using System.Collections.Generic;
using Library.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType == "application/vnd.marcin.hateoas+json")
            {
                var links = new List<LinkDto>();

                links.Add(
                    new LinkDto(Url.Link("GetRoot", new { }),
                    "self",
                    "GET"));

                links.Add(
                    new LinkDto(Url.Link("GetAuthors", new { }),
                    "authors",
                    "GET"));

                links.Add(
                    new LinkDto(Url.Link("CreateAuthor", new { }),
                    "create_author",
                    "Post"));

                return Ok(links);
            }
            return NoContent();
        }
    }
}