using System;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents;

public class _HeaderViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }

}
