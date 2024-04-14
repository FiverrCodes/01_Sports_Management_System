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

        public IActionResult View(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            var viewModel = new CompetitorVm
            {
                Competitor = _unitOfWork.Competitor.Get(x => x.Id == id),
                SelectedGameIds = _unitOfWork.CompetitorGame.GetAll(x => x.CompetitorId == id)
                                             .Select(x => x.GameId).ToList()
            };

            if (viewModel.Competitor == null)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            ViewBag.Games = _unitOfWork.Game.GetAll().OrderBy(x => x.Name).ToList();

            return View(viewModel);
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
            ViewBag.Games = _unitOfWork.Game.GetAll().ToList();

            if (obj.SelectedGameIds == null || obj.SelectedGameIds?.Count() == 0)
            {
                TempData["error"] = "Competitor should participate in at least one Game!";
                return View(obj);
            }

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

                _unitOfWork.Save();
                TempData["success"] = "Competitor Added Successfully!";

                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            var viewModel = new CompetitorVm
            {
                Competitor = _unitOfWork.Competitor.Get(x => x.Id == id),
                SelectedGameIds = _unitOfWork.CompetitorGame.GetAll(x => x.CompetitorId == id)
                                             .Select(x => x.GameId).ToList()
            };

            if (viewModel.Competitor == null)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            ViewBag.Games = _unitOfWork.Game.GetAll().OrderBy(x => x.Name).ToList();

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(CompetitorVm obj)
        {
            ViewBag.Games = _unitOfWork.Game.GetAll().ToList();

            if (obj.SelectedGameIds == null || obj.SelectedGameIds?.Count() == 0)
            {
                TempData["error"] = "Competitor should participate in at least one Game!";
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Competitor.Update(obj.Competitor);

                var existingCompetotorGames = _unitOfWork.CompetitorGame.GetAll(x => x.CompetitorId == obj.Competitor.Id)
                                                                        .ToList();
                if (existingCompetotorGames.Count() > 0)
                {
                    _unitOfWork.CompetitorGame.RemoveRange(existingCompetotorGames);
                }

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

                _unitOfWork.Save();
                TempData["success"] = "Competitor Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            var viewModel = new CompetitorVm
            {
                Competitor = _unitOfWork.Competitor.Get(x => x.Id == id),
                SelectedGameIds = _unitOfWork.CompetitorGame.GetAll(x => x.CompetitorId == id)
                                             .Select(x => x.GameId).ToList()
            };

            if (viewModel.Competitor == null)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            ViewBag.Games = _unitOfWork.Game.GetAll().OrderBy(x => x.Name).ToList();

            return View(viewModel);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            Competitor? competitor = _unitOfWork.Competitor.Get(x => x.Id == id);

            if (competitor == null)
            {
                TempData["error"] = "Competitor does not exists!";
                return NotFound();
            }

            _unitOfWork.Competitor.Remove(competitor);

            var competitorGames = _unitOfWork.CompetitorGame.GetAll(x => x.CompetitorId == id).ToList();

            if (competitorGames.Count() > 0)
            {
                _unitOfWork.CompetitorGame.RemoveRange(competitorGames);
            }

            _unitOfWork.Save();
            TempData["success"] = "Game Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
