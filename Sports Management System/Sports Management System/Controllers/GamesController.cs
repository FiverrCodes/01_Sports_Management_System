using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sports_Management_System.Models;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Game> games = _unitOfWork.Game.GetAll().OrderBy(x => x.Name).ToList();
            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game obj)
        {
            if (IsCodeExists(null, obj.Code))
            {
                TempData["error"] = "Game Code already exists!";
                return View();
            }

            if (IsNameExists(null, obj.Name))
            {
                TempData["error"] = "Game Name already exists!";
                return View();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Game.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Game Created Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Game does not exists!";
                return NotFound();
            }

            Game? game = _unitOfWork.Game.Get(x => x.Id == id);

            if (game == null)
            {
                TempData["error"] = "Game does not exists!";
                return NotFound();
            }

            return View(game);
        }
        [HttpPost]
        public IActionResult Edit(Game obj)
        {
            if (IsCodeExists(obj.Id, obj.Code))
            {
                TempData["error"] = "Game Code already exists!";
                return View();
            }

            if (IsNameExists(obj.Id, obj.Name))
            {
                TempData["error"] = "Game Name already exists!";
                return View();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Game.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Game Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                TempData["error"] = "Game does not exists!";
                return NotFound();
            }

            Game? game = _unitOfWork.Game.Get(x => x.Id == id);

            if (game == null)
            {
                TempData["error"] = "Game does not exists!";
                return NotFound();
            }

            return View(game);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            Game? game = _unitOfWork.Game.Get(x => x.Id == id);

            if (game == null)
            {
                TempData["error"] = "Game does not exists!";
                return NotFound();
            }

            _unitOfWork.Game.Remove(game);

            var competitorGames = _unitOfWork.CompetitorGame.GetAll(x => x.GameId == id).ToList();

            if (competitorGames.Count() > 0)
            {
                _unitOfWork.CompetitorGame.RemoveRange(competitorGames);
            }

            _unitOfWork.Save();
            TempData["success"] = "Game Deleted Successfully!";
            return RedirectToAction("Index");
        }

        #region Private
        private bool IsNameExists(Guid? id, string name)
        {
            bool isNameExists = false;

            List<Game> games = _unitOfWork.Game.GetAll().ToList();

            if (id != null)
            {
                isNameExists = games.Any(x => x.Id != id && x.Name.Trim().ToLower() == name.Trim().ToLower());
            }
            else
            {
                isNameExists = games.Any(x => x.Name.Trim().ToLower() == name.Trim().ToLower());
            }

            return isNameExists;
        }

        private bool IsCodeExists(Guid? id, string code)
        {
            bool isNameExists = false;

            List<Game> games = _unitOfWork.Game.GetAll().ToList();

            if (id != null)
            {
                isNameExists = games.Any(x => x.Id != id && x.Code.Trim().ToLower() == code.Trim().ToLower());
            }
            else
            {
                isNameExists = games.Any(x => x.Code.Trim().ToLower() == code.Trim().ToLower());
            }

            return isNameExists;
        }
        #endregion
    }
}
