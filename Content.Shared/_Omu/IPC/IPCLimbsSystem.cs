using Content.Shared._Shitmed.Body.Part;
using Content.Shared.Body.Part;
using Content.Shared.Hands;
using Content.Shared.Interaction;
using Content.Shared.Movement.Events;
using Content.Shared.Projectiles;
using Content.Shared.Weapons.Misc;
using Content.Shared.Weapons.Ranged.Components;
using Content.Shared.Weapons.Ranged.Systems;
using Robust.Shared.Physics;
using Robust.Shared.Toolshed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content.Shared._Omu.IPC;

public abstract class IPCLimbsSystem : EntitySystem
{

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<IpcLimbsComponent, ComponentStartup>(OnStartup);
        SubscribeLocalEvent<IpcLimbsComponent, BodyPartAddedEvent>(OnBodyPartAdd);
        SubscribeLocalEvent<IpcLimbsComponent, BodyPartRemovedEvent>(OnBodyPartRemoved);
    }

    private void OnStartup(Entity<IpcLimbsComponent> ent, ref ComponentStartup args)
    {
        return;
    }

    private void OnBodyPartAdd(EntityUid uid, IpcLimbsComponent component, ref BodyPartAddedEvent args)
    {
        component.bodyOwner = uid;
    }

    private void OnBodyPartRemoved(EntityUid uid, IpcLimbsComponent component, ref BodyPartRemovedEvent args)
    {
        if (component.bodyOwner != null)
        {
            component.bodyOwner = null;
        }
    }
}
