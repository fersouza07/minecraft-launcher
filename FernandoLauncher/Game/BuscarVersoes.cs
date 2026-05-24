using CmlLib.Core;
using Spectre.Console;
using System.Collections.Generic;

public class Versoes
{
    private readonly MinecraftLauncher launcher;

    public Versoes(MinecraftLauncher launcher)
    {
        this.launcher = launcher;
    }

    public async Task<List<string>> BuscarVersoes()
    {
        var versoes = await launcher.GetAllVersionsAsync();
        var listaVersoes = new List<string>();

        foreach (var versao in versoes)
        {
           if (versao.Type == "release")
            {
                listaVersoes.Add(versao.Name);
            }
        }

        return listaVersoes;
        
    }


}