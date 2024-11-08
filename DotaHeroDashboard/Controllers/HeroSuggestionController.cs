using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using DotaHeroDashboard.Services;
using DotaHeroDashboard.Models;

namespace DotaHeroDashboard.Controllers;

public class PlayerRequest
{
    public string PlayerId { get; set; } = string.Empty;
}

public class HeroSuggestionController : Controller
{
    private readonly IOpenDotaService _openDotaService;

    public HeroSuggestionController(IOpenDotaService openDotaService)
    {
        _openDotaService = openDotaService;
    }

    [HttpPost]
    public async Task<IActionResult> GetHeroSuggestions([FromBody] PlayerRequest request)
    {
        if (string.IsNullOrEmpty(request?.PlayerId))
        {
            return BadRequest("Player ID is required.");
        }

        var playerHeroes = await _openDotaService.GetHeroByPlayer(request.PlayerId);
        var metaHeroes = await _openDotaService.GetMetaHeroesAsync();

        var suggestions = playerHeroes
            .Where(hero => hero.Games > 10 && (double)hero.Win / hero.Games > 0.55)
            .Join(metaHeroes,
                playerHero => playerHero.HeroId,
                metaHero => metaHero.Id,
                (playerHero, metaHero) => new HeroSuggestionModel
                {
                    HeroId = playerHero.HeroId,
                    Games = playerHero.Games,
                    Win = playerHero.Win,
                    LocalizedName = metaHero.LocalizedName,
                    Img = metaHero.Img,
                    Roles = metaHero.Roles,
                    AttackType = metaHero.AttackType
                })
            .OrderByDescending(h => h.Games)
            .ThenByDescending(h => (double)h.Win / h.Games)
            .Take(5)
            .ToList();

        return PartialView("HeroSuggestion", suggestions);
    }

    public IActionResult Index()
    {
        return View();
    }
}
