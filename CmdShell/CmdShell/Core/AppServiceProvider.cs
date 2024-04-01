using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdShell.Core;

internal static class AppServiceProvider
{
    private static IServiceProvider Provider { get; set; } = null!;
    public static IServiceCollection Services { get; }


    static AppServiceProvider()
    {
        Services = new ServiceCollection();
    }

    internal static void BuildProvider()
    {
        Provider = Services.BuildServiceProvider();
    }

    internal static T? GetService<T>()
    {
        return Provider.GetService<T>();
    }

    internal static T GetRequiredService<T>() where T : notnull
    {
        return Provider.GetRequiredService<T>();
    }
}
