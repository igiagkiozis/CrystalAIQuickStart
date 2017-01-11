using Crystal;


namespace CrystalQuickStart {

  public class ThirstConsideration : ConsiderationBase<FooContext> {
    IEvaluator _evaluator;
    public static readonly string Name = "ThirstConsideration";

    public override void Consider(FooContext context) {
      Utility = new Utility(_evaluator.Evaluate(context.Thirst), Weight);
    }

    public override IConsideration Clone() {
      return new ThirstConsideration(this);
    }

    public ThirstConsideration() {
      Initialize();
    }

    ThirstConsideration(ThirstConsideration other) : base(other) {
      Initialize();
    }

    public ThirstConsideration(IConsiderationCollection collection)
      : base(Name, collection) {
      Initialize();
    }

    void Initialize() {
      var ptA = new Pointf(25f, 0f);
      var ptB = new Pointf(100f, 1f);
      _evaluator = new SigmoidEvaluator(ptA, ptB, 0.7f);
    }
  }


}
