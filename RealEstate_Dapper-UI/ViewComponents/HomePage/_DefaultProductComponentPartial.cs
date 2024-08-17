using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;


namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultProductComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory httpClientFactory;

    public _DefaultProductComponentPartial(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("http://localhost:5086/api/Products/ProductWithCategoryList");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View();
    
    }

}
