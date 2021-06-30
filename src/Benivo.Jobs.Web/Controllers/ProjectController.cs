using System.Linq;
using System.Threading.Tasks;
using Benivo.Jobs.Core;
using Benivo.Jobs.Core.ProjectAggregate;
using Benivo.Jobs.Core.ProjectAggregate.Specifications;
using Benivo.Jobs.SharedKernel.Interfaces;
using Benivo.Jobs.Web.ApiModels;
using Benivo.Jobs.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Benivo.Jobs.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:int}")]
        public async Task<IActionResult> Index(int projectId = 1)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Items = project.Items
                            .Select(item => ToDoItemViewModel.FromToDoItem(item))
                            .ToList()
            };
            return View(dto);
        }
    }
}
