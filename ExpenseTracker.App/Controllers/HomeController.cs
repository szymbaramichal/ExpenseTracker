using System.Diagnostics;
using ExpenseTracker.Business.Models.Errors;
using ExpenseTracker.Business.Models.Stocks;
using ExpenseTracker.Business.Services.FamilyService;
using ExpenseTracker.Core.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExpenseTracker.App.Controllers;

public class HomeController(IFamilyService familyService, 
    IConfiguration configuration, IHttpClientFactory httpClientFactory) : Controller
{

    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString(SessionFields.ID);
        if(userId is not null)
        {
            var familiesInfo = await familyService.GetFamiliesInfoForUser(int.Parse(userId));
            ViewBag.FamiliesInfo = familiesInfo.ResultModel;
            return View("LoggedInIndex");
        }
        else
        {
            return RedirectToAction(nameof(NotLoggedInIndex));
        }
    }
    
    public async Task<IActionResult> NotLoggedInIndex()
    {
        var httpClient = httpClientFactory.CreateClient(HttpClientsNames.MarketClient);
        var apiKey = configuration.GetValue<string>("Integrations:MarketApiKey");
            
        string dateFrom = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
        string dateTo = DateTime.Now.ToString("yyyy-MM-dd");
            
        var respone = await httpClient.GetAsync($"eod?access_key={apiKey}&symbols=TSLA&date_from={dateFrom}&date_to={dateTo}");
        var result = await respone.Content.ReadAsStringAsync();
        
        return View(JsonConvert.DeserializeObject<StockDataModel>(result));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
