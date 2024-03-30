
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();
services.AddSingleton<IRenderer, Renderer2D>();
services.AddTransient<Unit>();

ServiceProvider provider = services.BuildServiceProvider();

//IRenderer renderer = provider.GetRequiredService<IRenderer>();
//renderer.Render();

//Unit unit = provider.GetRequiredService<Unit>();
//unit.Show();


interface IRenderer
{
    public void Render();
}

class Renderer2D : IRenderer
{
    public void Render()
    {
        Console.WriteLine("Renderer2D");
    }
}

class Renderer3D : IRenderer
{
    public void Render()
    {
        Console.WriteLine("Renderer3D");
    }
}


class Unit
{
    public IRenderer Renderer { get; set; }

    public Unit(IRenderer renderer)
    {
        Renderer = renderer;
    }

    public void Show()
    {
        Renderer.Render();
    }
}

