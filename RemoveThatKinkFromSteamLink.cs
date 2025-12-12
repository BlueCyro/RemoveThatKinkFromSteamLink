using ResoniteModLoader;
using FrooxEngine;

namespace RemoveThatKinkFromSteamLink;

public class RemoveThatKinkFromSteamLink : ResoniteMod
{
    public override string Name => "RemoveThatKinkFromSteamLink";
    public override string Author => "Cyro";
    public override string Version => typeof(RemoveThatKinkFromSteamLink).Assembly.GetName().Version?.ToString() ?? "1.0.0";
    
    public static ModConfiguration? Config;

    public override void OnEngineInit()
    {
        Config = GetConfiguration();
        Config?.Save(true);

        Engine.Current.RunPostInit(() => {
            Msg("Registering Steam Link OSC driver ANYWAYS because I'm evil and bypassed the check >:)))");
            Engine.Current.InputInterface.RegisterInputDriver(new SteamLinkOSC_Driver());
        });
    }
}

