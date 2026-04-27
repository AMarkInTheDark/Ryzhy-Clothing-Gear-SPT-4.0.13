using System.Reflection;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;

namespace RyzhyBackport;

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class RyzhyMod(
    WTTServerCommonLib.WTTServerCommonLib wttCommon
) : IOnLoad
{
    public async Task OnLoad()
    {
        var assembly = Assembly.GetExecutingAssembly();
        await wttCommon.CustomItemServiceExtended.CreateCustomItems(assembly);
        await wttCommon.CustomClothingService.CreateCustomClothing(assembly);
        await Task.CompletedTask;
    }
}
