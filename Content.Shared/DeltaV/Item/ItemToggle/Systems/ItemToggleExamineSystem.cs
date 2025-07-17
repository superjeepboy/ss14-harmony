using Content.Shared.Examine;
using Content.Shared.Item.ItemToggle;

namespace Content.Shared.DeltaV.Item.ItemToggle.Systems;

public sealed class ItemToggleExamineSystem : EntitySystem
{
    [Dependency] private readonly ItemToggleSystem _toggle = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<DeltaV.Item.ItemToggle.Components.ItemToggleExamineComponent, ExaminedEvent>(OnExamined);
    }

    private void OnExamined(Entity<DeltaV.Item.ItemToggle.Components.ItemToggleExamineComponent> ent, ref ExaminedEvent args)
    {
        var msg = _toggle.IsActivated(ent.Owner) ? ent.Comp.On : ent.Comp.Off;
        args.PushMarkup(Loc.GetString(msg));
    }
}
