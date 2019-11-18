using System.Collections.Generic;

namespace Library.Api.Models
{
    public class LinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}