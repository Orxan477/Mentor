using Microsoft.AspNetCore.Mvc;

namespace MentorRazorPage.Areas.admin.ViewComponents
{
    public class AdminFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
