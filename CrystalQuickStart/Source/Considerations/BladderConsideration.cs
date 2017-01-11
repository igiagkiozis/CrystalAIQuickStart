using Crystal;


namespace CrystalQuickStart {
  // This extends the generic version of ConsiderationBase which has the added 
  // convenience that the Consider override "knows" about our custom context
  // since we've passed it in as a template parameter. The cost is increased 
  // level of indirection. But this is a simple example so we're aiming at 
  // simplicity, not performance.
  public class BladderConsideration : ConsiderationBase<FooContext> {
    IEvaluator _evaluator;
    // This is used as a type Id. Could use reflection, but its ugly... to
    // each his own I suppose. 
    public static readonly string Name = "BladderConsideration";

    public override void Consider(FooContext context) {
      Utility = new Utility(_evaluator.Evaluate(context.Bladder), Weight);
    }

    // This override is essential since this is how different AIs get their
    // own copies of this consideration. I'm not entirely satisfied with the
    // name this has, since this will usually be a *selective* clone of the 
    // original. I haven't a found better name so far, any suggestions would be 
    // welcome.
    public override IConsideration Clone() {
      return new BladderConsideration(this);
    }

    public BladderConsideration() {
      Initialize();
    }

    // A copy constructor must be present in every consideration.
    BladderConsideration(BladderConsideration other) : base(other) {
      Initialize();
    }

    public BladderConsideration(IConsiderationCollection collection)
      : base(Name, collection) {
      Initialize();
    }

    void Initialize() {
      // Point "a" in the interactive plots below.
      var ptA = new Pointf(50f, 0f);
      // Point "b" in the plots below.
      var ptB = new Pointf(100f, 1f);
      // This says that as the value of the Bladder property approaches 100, it 
      // becomes increasingly more important to do something about it. If this 
      // was a LinearEvaluator, that would ignore the sense of urgency, that is
      // quite familiar to everyone with a bladder, to take action when their 
      // bladder is nearly full.
      _evaluator = new PowerEvaluator(ptA, ptB, 6f);
    }
  }

}
