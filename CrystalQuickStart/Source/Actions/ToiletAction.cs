using Crystal;


namespace CrystalQuickStart {
  public class ToiletAction : ActionBase<FooContext> {
    public static readonly string Name = "Toilet";

    public override IAction Clone() {
      return new ToiletAction(this);
    }

    protected override void OnExecute(FooContext context) {
      context.Report(Name);
      context.Bladder -= 90f;
      context.Hunger += 25f;
      EndInSuccess(context);
    }

    public ToiletAction() {
    }

    ToiletAction(ToiletAction other) : base(other) {
    }

    public ToiletAction(IActionCollection collection) : base(Name, collection) {
    }
  }
}
