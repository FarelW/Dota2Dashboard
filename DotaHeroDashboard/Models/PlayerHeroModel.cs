using Newtonsoft.Json;

namespace DotaHeroDashboard.Models;
public class PlayerHeroModel
{
    [JsonProperty("hero_id")]
    public int HeroId { get; set; }

    [JsonProperty("last_played")]
    public int LastPlayed { get; set; }

    [JsonProperty("games")]
    public int Games { get; set; }

    [JsonProperty("win")]
    public int Win { get; set; }

    [JsonProperty("with_games")]
    public int WithGames { get; set; }

    [JsonProperty("with_win")]
    public int WithWin { get; set; }

    [JsonProperty("against_games")]
    public int AgainstGames { get; set; }

    [JsonProperty("against_win")]
    public int AgainstWin { get; set; }
}
