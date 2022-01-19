using Microsoft.AspNetCore.Mvc;

namespace MentorRazorPage.Areas.admin.ViewComponents
{
    public class SidebarViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
