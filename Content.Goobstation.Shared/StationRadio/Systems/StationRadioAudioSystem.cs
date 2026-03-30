using Content.Omu.Common.CCVar;
using Content.Goobstation.Shared.StationRadio.Components;
using Content.Goobstation.Shared.StationRadio.Events;
using Content.Shared.Interaction;
using Content.Shared.Power;
using Content.Shared.Power.EntitySystems;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Configuration;


namespace Content.Goobstation.Shared.StationRadio.Systems;

public sealed class StationRadioAudioSystem : EntitySystem
{
    [Dependency] private readonly SharedAudioSystem _audio = default!;
    [Dependency] private readonly IConfigurationManager _cfgMan = default!;
    
    // Omustation - volume controller for station radio
    private float _volume = 0f;

    // public override void Initialize()
    // {
    //     base.Initialize();

    //     _cfgMan.OnValueChanged(OmuCVars.StationRadioVolume, StationRadioCVarChanged);
    //     SubscribeLocalEvent<StationRadioLocalAudioComponent, StationRadioLocalAudioChangeEvent>(OnAudioChange);
    // }

    // private void StationRadioCVarChanged(float obj) 
    // {
    //     // _volume = SharedAudioSystem.GainToVolume(obj);

    //     // var query = EntityQueryEnumerator<StationRadioReceiverComponent>();
    //     // while (query.MoveNext(out var receiver, out var receiverComponent))
    //     // {
    //     //     if (!receiverComponent.SoundEntity.HasValue)
    //     //         RaiseLocalEvent(receiver, new StationRadioLocalAudioChangeEvent());
    //     // }

    //     // RaiseLocalEvent(receiver, new StationRadioLocalAudioChangeEvent());
    // }

    // private void OnAudioChange(EntityUid uid, StationRadioLocalAudioComponent comp, StationRadioLocalAudioChangeEvent args)
    // {
        
    //     _audio.SetVolume(comp.SoundEntity, _volume);
    
    // }
    
}
