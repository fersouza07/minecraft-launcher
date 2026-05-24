using System.Diagnostics;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using Spectre.Console;
public class Minecraft
{
    private readonly MinecraftLauncher launcher = new();

    public async Task<List<string>> BuscarVersoes()
    {
        var versoes = new Versoes(launcher);
        return await versoes.BuscarVersoes();
    }

    public async Task OpenMinecraft(string version, string user, bool download = true)
    {
        Process? jogo;
        MLaunchOption opcoes = new()
        {
            Session = MSession.CreateOfflineSession(user),
            MaximumRamMb = 4096
        };

        if (download)
        {
            jogo = await launcher.InstallAndBuildProcessAsync(version, opcoes);
        } else
        {
            jogo = await launcher.BuildProcessAsync(version, opcoes);
        }

        jogo.Start();
     }


}