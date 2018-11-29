using DevContactDirectory.Data.Repositories;
using DevContactDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevContactDirectory.Controllers
{
    public class DeveloperController : ApiController
    {
        private DeveloperRepository DeveloperRepository;

        public DeveloperController()
        {
            DeveloperRepository = new DeveloperRepository();
        }

        // GET: api/Developer
        /// <summary>
        /// Get all developers
        /// </summary>
        public IHttpActionResult Get()
        {
            var model =  DeveloperRepository.GetAll().Select(a => new DeveloperViewModel{ Firstname = a.Firstname , Lastname = a.Lastname, Email = a.Email , Category = a.Category.Name , Id = a.Id });

            return Ok(model);
        }

        // GET: api/Developer/5
        /// <summary>
        /// Gets a single developer
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult Get(int id)
        {

            if (id < 0)
            {
                return BadRequest();
            }
            var model = DeveloperRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // POST: api/Developer
        /// <summary>
        /// Create a new developer 
        /// </summary>
        public IHttpActionResult Post(DeveloperCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dev = new Developer();
            dev.Firstname = model.Firstname;
            dev.Lastname = model.Lastname;
            dev.Email = model.Email;
            dev.CategoryId = model.Category;

            var result = DeveloperRepository.Add(dev);

            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Developer);
        }

        /// <summary>
        /// Update an existing developer 
        /// </summary>
        public IHttpActionResult Put(DeveloperUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dev = DeveloperRepository.GetAll(a=>a.Id==model.Id).FirstOrDefault();

            if (dev == null)
            {
                return NotFound();
            }

            dev.Firstname = model.Firstname;
            dev.Lastname = model.Lastname;
            dev.Email = model.Email;
            dev.CategoryId = model.Category;

            var result = DeveloperRepository.Update(dev);
            return Ok(result);
        }

        // DELETE: api/Developer/5
        /// <summary>
        /// Remove an existing developer 
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var model = DeveloperRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            var result = DeveloperRepository.Remove(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
