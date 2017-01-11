using Crystal;


namespace CrystalQuickStart {

  public class QsAiConstructor : AiConstructor {
    protected override void DefineActions() {
      A = new DrinkAction(Actions);
      A = new EatAction(Actions);
      A = new ToiletAction(Actions);
      A = new IdleAction(Actions);
    }

    protected override void DefineConsiderations() {
      C = new BladderConsideration(Considerations);
      C = new HungerConsideration(Considerations);
      C = new ThirstConsideration(Considerations);
    }

    protected override void DefineOptions() {
      O = new Option("Drink", Options);
      O.SetAction(DrinkAction.Name);
      O.AddConsideration(ThirstConsideration.Name);

      O = new Option("Eat", Options);
      O.SetAction(EatAction.Name);
      O.AddConsideration(HungerConsideration.Name);

      O = new Option("Toilet", Options);
      O.SetAction(ToiletAction.Name);
      O.AddConsideration(BladderConsideration.Name);

      O = new ConstantUtilityOption("Idle", Options);
      O.SetAction(IdleAction.Name);
      O.DefaultUtility = new Utility(0.01f, 1f);
    }

    protected override void DefineBehaviours() {
      B = new Behaviour("DefaultBehaviour", Behaviours);
      B.AddOption("Drink");
      B.AddOption("Eat");
      B.AddOption("Toilet");
      B.AddOption("Idle");
    }

    protected override void ConfigureAi() {
      Ai = new UtilityAi("QuickStartAi", AIs);
      Ai.AddBehaviour("DefaultBehaviour");
    }

    public QsAiConstructor() : base(AiCollectionConstructor.Create()) {
    }
  }

}
