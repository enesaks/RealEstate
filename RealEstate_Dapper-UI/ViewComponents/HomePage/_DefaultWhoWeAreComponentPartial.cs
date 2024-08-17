using System;
using Microsoft.AspNetCore.Mvc;
namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultWhoWeAreComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
        // TODO: 14.Video da kaldın Who We Are Tablolarını oluşturucaksın.
    }
}
