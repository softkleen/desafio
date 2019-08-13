using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App2.Controllers
{
    [Route("showmethecode")]
    public class ShowMeController : ControllerBase
    {
        // GET showmethecode
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "https://github.com/softkleen/desafio.git" };
        }

    }
}
