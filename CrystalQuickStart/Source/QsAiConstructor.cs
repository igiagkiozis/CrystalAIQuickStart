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
      IsOkay(O.SetAction(DrinkAction.Name));
      IsOkay(O.AddConsideration(ThirstConsideration.Name));

      O = new Option("Eat", Options);
      IsOkay(O.SetAction(EatAction.Name));
      IsOkay(O.AddConsideration(HungerConsideration.Name));

      O = new Option("Toilet", Options);
      IsOkay(O.SetAction(ToiletAction.Name));
      IsOkay(O.AddConsideration(BladderConsideration.Name));

      O = new ConstantUtilityOption("Idle", Options);
      IsOkay(O.SetAction(IdleAction.Name));
      O.DefaultUtility = new Utility(0.01f, 1f);
    }

    protected override void DefineBehaviours() {
      B = new Behaviour("DefaultBehaviour", Behaviours);
      IsOkay(B.AddOption("Drink"));
      IsOkay(B.AddOption("Eat"));
      IsOkay(B.AddOption("Toilet"));
      IsOkay(B.AddOption("Idle"));
    }

    protected override void ConfigureAi() {
      Ai = new UtilityAi("QuickStartAi", AIs);
      IsOkay(Ai.AddBehaviour("DefaultBehaviour"));
    }

    public QsAiConstructor() : base(AiCollectionConstructor.Create()) {
    }
  }

}
