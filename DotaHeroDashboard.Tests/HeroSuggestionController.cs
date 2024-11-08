namespace DotaHeroDashboard.Tests;
public class HeroSuggestionControllerTests
{
    [Fact]
    public async Task GetHeroSuggestions_ReturnsPartialView_WithSuggestions()
    {
        var mockService = new Mock<IOpenDotaService>();
        
        mockService.Setup(service => service.GetHeroByPlayer(It.IsAny<string>()))
            .ReturnsAsync(new List<PlayerHeroModel>
            {
                new PlayerHeroModel { HeroId = 1, Games = 20, Win = 15 },
                new PlayerHeroModel { HeroId = 2, Games = 25, Win = 17 }
            });

        mockService.Setup(service => service.GetMetaHeroesAsync())
            .ReturnsAsync(new List<HeroModel>
            {
                new HeroModel { Id = 1, LocalizedName = "Hero1", Name = "npc_dota_hero_1", Icon = "/icons/hero1.png", Img = "/img/hero1.png", Roles = new List<string>{"Carry"}, AttackType = "Melee", PrimaryAttr = "agi" },
                new HeroModel { Id = 2, LocalizedName = "Hero2", Name = "npc_dota_hero_2", Icon = "/icons/hero2.png", Img = "/img/hero2.png", Roles = new List<string>{"Support"}, AttackType = "Ranged", PrimaryAttr = "int" }
            });

        var controller = new HeroSuggestionController(mockService.Object);

        var playerRequest = new PlayerRequest { PlayerId = "12345" };
        
        // Act
        var result = await controller.GetHeroSuggestions(playerRequest) as PartialViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("HeroSuggestion", result?.ViewName);
        Assert.IsType<List<HeroSuggestionModel>>(result?.Model);

        var suggestions = result?.Model as List<HeroSuggestionModel>;
        Assert.NotNull(suggestions);
        Assert.True(suggestions.Count <= 5);
    }

    [Fact]
    public void Index_ReturnsViewResult()
    {
        var mockService = new Mock<IOpenDotaService>();
        var controller = new HeroSuggestionController(mockService.Object);

        var result = controller.Index();

        Assert.IsType<ViewResult>(result);
    }
}