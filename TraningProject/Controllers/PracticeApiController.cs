using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainingProject.Core.Models;

namespace TraningProject.API.Controllers
{
    [Route("apis/practice")]
    public class PracticeApiController : ControllerBase
    {
        public PracticeApiController()
        {
        }

        [HttpGet, Route("api1")]
        public IActionResult API1()
        {
            return Ok("Passed API 1");
        }

        [HttpPost, Route("api2")]
        public IActionResult API2()
        {
            return Ok("Passed API 2");
        }

        [HttpPut, Route("api3")]
        public IActionResult API3()
        {
            return Ok("Passed API 3");
        }

        [HttpDelete, Route("api4")]
        public IActionResult API4()
        {
            return Ok("Passed API 4");
        }

        [HttpGet, Route("api5/{param1}/{param2}")]
        public IActionResult API5(string param1, string param2)
        {
            if (param1 == "abc" && param2 == "xyz")
            {
                return Ok("Passed API 5");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet, Route("api6/{param1:guid}/{param2:int}")]
        public IActionResult API6(Guid param1, int param2)
        {
            if (param1 == new Guid("1DA405A4-FC3E-45C4-BB18-2D444D05C3F5") && param2 == 123)
            {
                return Ok("Passed API 6");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete, Route("api7/{param1}")]
        public IActionResult API7(string param1)
        {
            if (param1 == "abc?xyz")
            {
                return Ok("Passed API 7");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete, Route("api8")]
        public IActionResult API8(string param1, int param2)
        {
            if (param1 == "abc" && param2 == 123)
            {
                return Ok("Passed API 8");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete, Route("api9/{param2}")]
        public IActionResult API9(string param1, int param2)
        {
            if (param1 == "abc" && param2 == 123)
            {
                return Ok("Passed API 9");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpDelete, Route("api10/{param1}/and/{param2}")]
        public IActionResult API10(string param1, string param2, int param3)
        {
            if (param1 == "abc" && param2 == "xyz" && param3 == 123)
            {
                return Ok("Passed API 10");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpPost, Route("api11")]
        public IActionResult API11([FromBody] Information information)
        {
            if (information.Title == "abc" && information.Description == "xyz")
            {
                return Ok("Passed API 11");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpPost, Route("api12/{param1}")]
        public IActionResult API12([FromBody] Information model, int param1, string param2)
        {
            if (model.Title == "abc" && model.Description == "xyz" && param1 == 321 && param2 == "xyz")
            {
                return Ok("Passed API 12");
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet, Route("api13")]
        public IActionResult API13()
        {
            if (Request.Cookies.TryGetValue("secret", out string secret) && secret == "abc")
            {
                return Ok("Passed API 13");
            }
            else {
                throw new Exception();
            }
        }
    }
}
