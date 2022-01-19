using Microsoft.AspNetCore.Mvc;

namespace MentorRazorPage.Areas.admin.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
