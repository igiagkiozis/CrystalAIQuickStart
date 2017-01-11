using Crystal;

namespace CrystalQuickStart {
  public class IdleAction : ActionBase<FooContext> {
    public static readonly string Name = "Idle";

    public override IAction Clone() {
      return new IdleAction(this);
    }

    protected override void OnExecute(FooContext context) {
      context.Report(Name);
      context.Bladder += 1f;
      context.Hunger += 1.5f;
      context.Thirst += 2.2f;
      EndInSuccess(context);
    }

    public IdleAction() {
    }

    IdleAction(IdleAction other) : base(other) {
    }

    public IdleAction(IActionCollection collection) : base(Name, collection) {
    }
  }
}
