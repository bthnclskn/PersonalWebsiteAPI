using System.Collections.Generic;
using PersonalWebsiteAPI.Models;

namespace PersonalWebsiteAPI.Repositories
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(int id);
    }
}
