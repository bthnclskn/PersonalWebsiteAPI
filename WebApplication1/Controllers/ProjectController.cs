using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsiteAPI.Models;
using PersonalWebsiteAPI.Repositories;

namespace PersonalWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return _projectRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPost]
        public ActionResult<Project> Post([FromBody] Project project)
        {
            _projectRepository.Add(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            var existingProject = _projectRepository.GetById(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            _projectRepository.Update(project);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            _projectRepository.Delete(id);
            return NoContent();
        }
    }
}
