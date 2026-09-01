// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Aiden <aiden@djkraz.com>
// SPDX-FileCopyrightText: 2025 BombasterDS <115770678+BombasterDS@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 BombasterDS <deniskaporoshok@gmail.com>
// SPDX-FileCopyrightText: 2025 BombasterDS2 <shvalovdenis.workmail@gmail.com>
// SPDX-FileCopyrightText: 2025 Misandry <mary@thughunt.ing>
// SPDX-FileCopyrightText: 2025 SX_7 <sn1.test.preria.2002@gmail.com>
// SPDX-FileCopyrightText: 2025 gus <august.eymann@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Client.UserInterface.Controls;
using Content.Shared._Omu.IPC;
using Content.Shared.Atmos.Components;
using Content.Shared.Body.Part;
using Content.Shared.Body.Prototypes;
using Content.Shared.Clothing.Components;
using Content.Shared.Item;
using Content.Shared.Preferences.Loadouts;
using Content.Shared.Roles;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Prototypes;
using System.Numerics;

namespace Content.Client._Omu.IPCLimbs.UI;

public sealed partial class ToggleLimbsAccess : RadialMenu
{
    [Dependency] private readonly EntityManager _entityManager = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
    private readonly ProtoId<BodyPrototype> ipcBodyProto = "IPC";

    public event Action<EntityUid>? SendToggleClothingMessageAction;

    public EntityUid Entity { get; set; }

    public ToggleLimbsAccess()
    {
        IoCManager.InjectDependencies(this);
        RobustXamlLoader.Load(this);
    }

    public void SetEntity(EntityUid uid)
    {
        Entity = uid;
        RefreshUI();
    }

    public void RefreshUI()
    {
        var main = FindControl<RadialContainer>("Main");

        var limbsEnum = _entityManager.EntityQueryEnumerator<IpcLimbsComponent, BodyPartComponent>();

        while (limbsEnum.MoveNext(out var uid, out var limbsComp, out var bodyPartComp))
        {
            if (bodyPartComp.Body != Entity)
                continue;

            if (!_entityManager.TryGetComponent<MetaDataComponent>(uid, out var meta))
                continue;

            var button = new ToggleLimbsAccessButton()
            {
                SetSize = new Vector2(64, 64),
                ToolTip = meta.EntityName,
                limbsId = uid
            };

            var spriteView = new SpriteView()
            {
                SetSize = new Vector2(48, 48),
                VerticalAlignment = VAlignment.Center,
                HorizontalAlignment = HAlignment.Center,
                Stretch = SpriteView.StretchMode.Fill
            };

            spriteView.SetEntity(uid);

            button.AddChild(spriteView);
            main.AddChild(button);
        }


        AddToggleableLimbMenuButtonOnClickAction(main);
    }

    private void AddToggleableLimbMenuButtonOnClickAction(Control control)
    {
        var mainControl = control as RadialContainer;

        if (mainControl == null)
            return;

        foreach (var child in mainControl.Children)
        {
            var castChild = child as ToggleLimbsAccessButton;

            if (castChild == null)
                return;

            castChild.OnPressed += _ =>
            {
                mainControl.DisposeAllChildren();
                RefreshUI();
            };
        }
    }
}

public sealed class ToggleLimbsAccessButton : RadialMenuButtonWithSector
{
    public EntityUid limbsId { get; set; }
}
