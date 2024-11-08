using Newtonsoft.Json;

namespace DotaHeroDashboard.Models;
public class HeroModel
{
    // Name
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("localized_name")]
    public required string LocalizedName { get; set; }

    // Image
    [JsonProperty("img")]
    public required string Img { get; set; }

    [JsonProperty("icon")]
    public required string Icon { get; set; }

    // Types
    [JsonProperty("primary_attr")]
    public required string PrimaryAttr { get; set; }

    [JsonProperty("attack_type")]
    public required string AttackType { get; set; }

    [JsonProperty("roles")]
    public List<string> Roles { get; set; } = new List<string>();

    // Pro Picks
    [JsonProperty("pro_pick")]
    public int ProPick { get; set; }

    [JsonProperty("pro_win")]
    public int ProWin { get; set; }

    [JsonProperty("pro_ban")]
    public int ProBan { get; set; }

    // Public Picks
    [JsonProperty("pub_pick")]
    public int PubPick { get; set; }

    [JsonProperty("pub_pick_trend")]
    public List<int> PubPickTrend { get; set; } = new List<int>();

    [JsonProperty("pub_win")]
    public int PubWin { get; set; }

    [JsonProperty("pub_win_trend")]
    public List<int> PubWinTrend { get; set; } = new List<int>();
}


