using Crystal;
namespace CrystalQuickStart {
  public class EatAction : ActionBase<FooContext> {
    public static readonly string Name = "Eat";

    public override IAction Clone() {
      return new EatAction(this);
    }

    protected override void OnExecute(FooContext context) {
      context.Report(Name);
      context.Hunger -= 80f;
      context.Bladder += 30f;
      EndInSuccess(context);
    }

    public EatAction() {
    }

    EatAction(EatAction other) : base(other) {
    }

    public EatAction(IActionCollection collection) : base(Name, collection) {
    }
  }
}
