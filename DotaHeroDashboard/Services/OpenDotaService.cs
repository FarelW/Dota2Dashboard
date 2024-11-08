using Newtonsoft.Json;
using DotaHeroDashboard.Models;

namespace DotaHeroDashboard.Services;

public interface IOpenDotaService
{
    Task<List<HeroModel>> GetHeroStatsAsync();
    Task<List<HeroModel>> GetMetaHeroesAsync();
    Task<List<PlayerHeroModel>> GetHeroByPlayer(string id);
}

public class OpenDotaService : IOpenDotaService
{
    private readonly HttpClient _httpClient;
    private List<HeroModel>? _heroesCache;

    public OpenDotaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<HeroModel>> GetHeroStatsAsync()
    {
        if (_heroesCache == null)
        {
            var response = await _httpClient.GetStringAsync("https://api.opendota.com/api/herostats");
            _heroesCache = JsonConvert.DeserializeObject<List<HeroModel>>(response) ?? new List<HeroModel>();
        }
        return _heroesCache;
    }

    public async Task<List<HeroModel>> GetMetaHeroesAsync()
    {
        var heroes = await GetHeroStatsAsync();

        var metaHeroes = heroes
            .Select(hero => new
            {
                Hero = hero,
                WinRate = hero.ProPick > 0 ? (double)hero.ProWin / hero.ProPick : 0,
                MetaScore = hero.ProPick + hero.ProBan + ((hero.ProPick > 0 ? (double)hero.ProWin / hero.ProPick : 0) * 100)
            })
            .Where(h => h.MetaScore > 0)
            .OrderByDescending(h => h.MetaScore)
            .Take(50)
            .Select(h => h.Hero)
            .ToList();

        return metaHeroes;
    }

    public async Task<List<PlayerHeroModel>> GetHeroByPlayer(string id)
    {
        var response = await _httpClient.GetStringAsync($"https://api.opendota.com/api/players/{id}/heroes");
        var heroes = JsonConvert.DeserializeObject<List<PlayerHeroModel>>(response);

        if (heroes == null || !heroes.Any())
        {
            Console.WriteLine("Error: No heroes found for the player.");
        }
        
        return heroes ?? new List<PlayerHeroModel>();
    }
}
