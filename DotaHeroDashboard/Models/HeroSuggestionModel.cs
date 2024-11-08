namespace DotaHeroDashboard.Models;
public class HeroSuggestionModel
{
    public int HeroId { get; set; }
    public int Games { get; set; }
    public int Win { get; set; }
    public required string LocalizedName { get; set; }
    public required string Img { get; set; }
    public List<string> Roles { get; set; } = new List<string>();
    public required string AttackType { get; set; }
}
