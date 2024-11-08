using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotaHeroDashboard.Models;
using DotaHeroDashboard.Services;

namespace DotaHeroDashboard.Controllers;

public class HeroController : Controller
{
    private readonly IOpenDotaService _openDotaService;

    public HeroController(IOpenDotaService openDotaService)
    {
        _openDotaService = openDotaService;
    }

    public async Task<List<HeroModel>> GetMetaHeroesAsync()
    {
        return await _openDotaService.GetMetaHeroesAsync();
    }

    public async Task<IActionResult> Index()
    {
        var metaHeroes = await GetMetaHeroesAsync();
        return View(metaHeroes);
    }
}
