﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Areas.People.Managers;
using Domain.Areas.People.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoAPI.Areas.People.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PeopleManager manager;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
            manager = new PeopleManager();
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDetailsModel>> Index(string searchTerm = null)
        {
            var search = new PersonSearchModel();
            search.Term = searchTerm;

            var response = manager.GetIndexModel(search);

            return Ok(response);
        }

        [HttpGet("{personId:long}")]
        public ActionResult<PersonDetailsModel> Details(long personId)
        {
            var response = manager.GetDetailsModel(personId);

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return response;
            }
        }

        [HttpPost]
        public ActionResult Create(PersonCreateModel model)
        {
            try
            {
                manager.SaveCreateModel(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }

        [HttpPut("{personId:long}")]
        public ActionResult Edit(long personId, PersonEditModel model)
        {
            try
            {
                manager.SaveEditModel(personId, model);

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{personId:long}")]
        public ActionResult Delete(long personId)
        {
            try
            {
                manager.Delete(personId);

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
