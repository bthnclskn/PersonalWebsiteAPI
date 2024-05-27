using System.Collections.Generic;
using System.Linq;
using PersonalWebsiteAPI.Models;

namespace PersonalWebsiteAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly List<Project> _projects = new List<Project>
        {
            new Project { Id = 1, Name = "Project 1", Description = "Description 1" },
            new Project { Id = 2, Name = "Project 2", Description = "Description 2" }
        };

        public IEnumerable<Project> GetAll() => _projects;

        public Project GetById(int id) => _projects.FirstOrDefault(p => p.Id == id);

        public void Add(Project project)
        {
            project.Id = _projects.Max(p => p.Id) + 1;
            _projects.Add(project);
        }

        public void Update(Project project)
        {
            var existingProject = GetById(project.Id);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
            }
        }

        public void Delete(int id)
        {
            var project = GetById(id);
            if (project != null)
            {
                _projects.Remove(project);
            }
        }
    }
}
