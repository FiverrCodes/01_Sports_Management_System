using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sports_Management_System.Models.ViewModels;
using Sports_Management_System.Repository.IRepository;

namespace Sports_Management_System.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var events = _unitOfWork.Event.GetAll().OrderBy(x => x.FeatureEvent).ToList();
            var games = _unitOfWork.Game.GetAll().ToList();

            var returnModel = new List<EventBaseVm>();

            if (events != null && events.Count > 0)
            {
                foreach (var @event in events)
                {
                    var vm = new EventBaseVm()
                    {
                        Id = @event.Id,
                        Game = games?.Where(x => x.Id == @event.GameId)?.FirstOrDefault()?.Name,
                        FeatureEvent = @event.FeatureEvent,
                        EventVenue = @event.EventVenue,
                        EventDate = @event.EventDate,
                        EventStartTime = @event.EventStartTime,
                        EventEndTime = @event.EventEndTime,
                    };

                    returnModel.Add(vm);
                }
            }

            return View(returnModel);
        }
    }
}
