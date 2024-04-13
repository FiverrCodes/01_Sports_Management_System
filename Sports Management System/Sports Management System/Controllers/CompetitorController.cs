using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var viewModel = new CompetitorVm
            {
                Competitor = new Competitor(),
                SelectedGameIds = new List<Guid>()
            };

            ViewBag.Games = _unitOfWork.Game.GetAll().OrderBy(x => x.Name).ToList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompetitorVm obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Competitor.Add(obj.Competitor);

                // Add CompetitorGame records for selected games
                if (obj.SelectedGameIds.Count() > 0)
                {
                    foreach (var gameId in obj.SelectedGameIds)
                    {
                        _unitOfWork.CompetitorGame.Add(new CompetitorGame
                        {
                            CompetitorId = obj.Competitor.Id,
                            GameId = gameId
                        });
                    }
                }
                else
                {
                    TempData["error"] = "Competitor should participate in at least one Game!";
                    return View();
                }

                _unitOfWork.Save();
                TempData["success"] = "Competitor Added Successfully!";

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Games = _unitOfWork.Game.GetAll().ToList();
            return View(obj);
        }
    }
}
