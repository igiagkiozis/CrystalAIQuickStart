using Crystal;


namespace CrystalQuickStart {


  public class DrinkAction : ActionBase<FooContext> {
    public static readonly string Name = "Drink";

    public override IAction Clone() {
      return new DrinkAction(this);
    }

    protected override void OnExecute(FooContext context) {
      context.Report(Name);
      context.Bladder += 25f;
      context.Thirst -= 90f;
      EndInSuccess(context);
    }

    public DrinkAction() {
    }

    DrinkAction(DrinkAction other) : base(other) {
    }

    public DrinkAction(IActionCollection collection) : base(Name, collection) {
    }
  }

}
