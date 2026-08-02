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

using System.Numerics;
using Content.Client.UserInterface.Controls;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._Omu.IPCLimbs.UI;

public sealed partial class ToggleLimbsAccess : RadialMenu
{
    [Dependency] private readonly EntityManager _entityManager = default!;

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

        AddToggleableClothingMenuButtonOnClickAction(main);
    }

    private void AddToggleableClothingMenuButtonOnClickAction(Control control)
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

public sealed class ToggleLimbsAccessButton : RadialMenuTextureButtonWithSector
{
    public EntityUid AttachedClothingId { get; set; }
}