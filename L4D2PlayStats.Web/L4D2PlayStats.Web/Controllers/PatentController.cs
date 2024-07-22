using L4D2PlayStats.Patents.Services;
using L4D2PlayStats.Ranking;
using L4D2PlayStats.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace L4D2PlayStats.Web.Controllers;

public class PatentController(IRankingServiceCached rankingServiceCached, IPatentService patentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.Patent = "active";

        var config = await rankingServiceCached.ExperienceConfigAsync();
        var patents = patentService.GetAllPatents();

        var model = new PatentModel(config, patents);

        return View(model);
    }
}