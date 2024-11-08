namespace DotaHeroDashboard.Tests;

public class HeroControllerTests
{
    [Fact]
    public async Task GetMetaHeroesAsync_ReturnsMetaHeroes()
    {
        var mockService = new Mock<IOpenDotaService>();
        var metaHeroes = new List<HeroModel>
        {
            new HeroModel { Id = 1, LocalizedName = "Hero1", Name = "npc_dota_hero_1", Icon = "/icons/hero1.png", Img = "/img/hero1.png", Roles = new List<string>{"Carry"}, AttackType = "Melee", PrimaryAttr = "agi" },
            new HeroModel { Id = 2, LocalizedName = "Hero2", Name = "npc_dota_hero_2", Icon = "/icons/hero2.png", Img = "/img/hero2.png", Roles = new List<string>{"Support"}, AttackType = "Ranged", PrimaryAttr = "int" }
        };
        mockService.Setup(service => service.GetMetaHeroesAsync()).ReturnsAsync(metaHeroes);

        var controller = new HeroController(mockService.Object);

        var result = await controller.GetMetaHeroesAsync();

        Assert.Equal(metaHeroes, result);
    }

    [Fact]
    public async Task Index_ReturnsViewResult_WithMetaHeroes()
    {
        var mockService = new Mock<IOpenDotaService>();
        mockService.Setup(service => service.GetMetaHeroesAsync())
            .ReturnsAsync(new List<HeroModel>
            {
                new HeroModel { Id = 1, LocalizedName = "Hero1", Name = "npc_dota_hero_1", Icon = "/icons/hero1.png", Img = "/img/hero1.png", Roles = new List<string>{"Carry"}, AttackType = "Melee", PrimaryAttr = "agi" },
                new HeroModel { Id = 2, LocalizedName = "Hero2", Name = "npc_dota_hero_2", Icon = "/icons/hero2.png", Img = "/img/hero2.png", Roles = new List<string>{"Support"}, AttackType = "Ranged", PrimaryAttr = "int" }
            });

        var controller = new HeroController(mockService.Object);

        var result = await controller.Index() as ViewResult;

        Assert.NotNull(result);
        Assert.IsType<ViewResult>(result);
        Assert.IsType<List<HeroModel>>(result.Model);
    }
}