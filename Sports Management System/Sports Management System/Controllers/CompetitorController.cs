using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sports_Management_System.Models;
using Sports_Management_System.Models.ViewModels;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CompetitorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompetitorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Competitor> competitors = _unitOfWork.Competitor.GetAll().OrderBy(x => x.FName).ToList();
            return View(competitors);
        }

        public IActionResult Create()
        {
            CompetitorVm competitor = new CompetitorVm()
            {
                GamesList = _unitOfWork.Game.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }),
                Competitor = new Competitor()
            };

            return View(competitor);
        }
    }
}
