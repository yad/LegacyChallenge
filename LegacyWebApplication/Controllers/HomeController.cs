using LegacyQuestTracker;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace LegacyWebApplication.Controllers
{
    [Authorize]
    public class HomeController : AsyncController
    {
        [HttpGet]
        public void IndexAsync()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            AsyncManager.OutstandingOperations.Increment();
            new QuestBook().GetQuests().ContinueWith((result) =>
            {
                AsyncManager.Parameters["quests"] = result.Result;
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public ActionResult IndexCompleted(IEnumerable<Quest> quests)
        {
            return View(quests);
        }
    }
}