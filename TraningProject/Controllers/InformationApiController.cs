using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainingProject.Core.Models;
using TrainingProject.Core.Services;

namespace TraningProject.API.Controllers
{
    [Route("apis/information")]
    public class InformationApiController : ControllerBase
    {
        IInformationService InformationService { get; }
        public InformationApiController(IInformationService informationService)
        {
            InformationService = informationService;
        }

        [HttpPost]
        public IActionResult Add(Information information)
        {
            information = InformationService.Add(information);
            return Ok(information);
        }

        [HttpPut]
        public IActionResult Update(Information information)
        {
            information = InformationService.Update(information);
            return Ok(information);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var information = InformationService.Get();
            return Ok(information);
        }

        [HttpGet, Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var information = InformationService.Get(id);
            return Ok(information);
        }

        [HttpDelete, Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            InformationService.Delete(id);
            return Ok();
        }

        [HttpGet, Route("search")]
        public IActionResult Search(string searchText)
        {
            var information = InformationService.Search(searchText);
            return Ok(information);
        }
    }
}
