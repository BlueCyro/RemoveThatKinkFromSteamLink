namespace FSharpResoMod

open ResoniteModLoader
open FrooxEngine


type RemoveThatKinkFromSteamLink() =
    inherit ResoniteMod()

    // [<DefaultValue>] static val mutable private harmonyInstance : Harmony


    [<DefaultValue>] static val mutable private config : ModConfiguration


    static member public Config
        with get() = RemoveThatKinkFromSteamLink.config
        and set(value) = RemoveThatKinkFromSteamLink.config <- value


    override ResoniteModBase.Name
        with get (): string = "RemoveThatKinkFromSteamLink"
    

    override ResoniteModBase.Author
        with get (): string = "Cyro"
    

    override ResoniteModBase.Version
        with get (): string = typeof<RemoveThatKinkFromSteamLink>.Assembly.GetName().Version.ToString()


    override ResoniteModBase.OnEngineInit (): unit = 
        // RemoveThatKinkFromSteamLink.harmonyInstance <- new Harmony "net.Cyro.RemoveThatKinkFromSteamLink"

        RemoveThatKinkFromSteamLink.config <- base.GetConfiguration ()
        if not (isNull RemoveThatKinkFromSteamLink.config) then
            RemoveThatKinkFromSteamLink.config.Save true

        //RemoveThatKinkFromSteamLink.harmonyInstance.PatchAll ()

        let inline postInitTask () : unit =
            RemoveThatKinkFromSteamLink.Msg "Registering Steam Link OSC driver ANYWAYS because I'm evil and bypassed the check >:)))"
            let inputDriver : SteamLinkOSC_Driver = new SteamLinkOSC_Driver ()
            Engine.Current.InputInterface.RegisterInputDriver inputDriver



        Engine.Current.RunPostInit postInitTask




(*
This is just an example of a harmony patch in F#
[<HarmonyPatch>]
module BootStrap_Patches =

    [<HarmonyPostfix>]
    [<HarmonyPatch(typeof<Userspace>, "Bootstrap")>]
    let Test() =
        RemoveThatKinkFromSteamLink.Msg "Successful bootstrap postfix from F#!!!!!!!!!"
*)


